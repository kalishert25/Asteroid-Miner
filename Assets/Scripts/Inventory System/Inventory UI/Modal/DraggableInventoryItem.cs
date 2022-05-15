using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableInventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IInitializePotentialDragHandler//, IPointerClickHandler
{
    private InventoryItem itemValue;
    [SerializeField]
    private TextMeshProUGUI m_StackLabel, m_TooltipLabel;
    [HideInInspector]
    public ItemSlot itemSlot;
    private ItemSlot lastItemSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public InventoryItem ItemValue { get { return itemValue; } set 
        {
            itemValue = value;
            gameObject.GetComponent<Image>().sprite = value.data.icon;
            m_StackLabel.text = value.stackSize.ToString();
            m_TooltipLabel.text = value.data.displayName;
        } 
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnDestroy()
    {
        if(itemSlot != null)
        {
            itemSlot.DeleteItem();
        }
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetSiblingIndex(-1);
        lastItemSlot = itemSlot;
        if(itemSlot != null)
        {
            Debug.Log(itemSlot.transform.position);
        }
        else
        {
            Debug.Log("No ItemSlot was found.");
        }
        
        canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(lastItemSlot == itemSlot && itemSlot != null)
        {
            itemSlot.Put(gameObject);
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    ((IPointerClickHandler)itemSlot).OnPointerClick(eventData);
    //}
}
