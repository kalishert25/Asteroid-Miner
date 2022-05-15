using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler //,IPointerClickHandler
{
    private GameObject currItem;
    private Vector2 offset;
    //private bool selected = false;
    //[SerializeField]
    //private Color selectedColor;
    //private Color nonSelectedColor;
    public GameObject CurrItem { get => currItem; private set => currItem = value; }

    private void Awake()
    {
        //nonSelectedColor = gameObject.GetComponent<Image>().color;
    }
    private void Start()
    {
        offset = gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition;
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Put(eventData.pointerDrag);
        }
    }
    public void Put(GameObject item)
    {
        if (item.GetComponent<DraggableInventoryItem>() is null) return;
        //if (currItem != null && currItem)
        //{
        //    item.GetComponent<DragDrop>().itemSlot.Put(currItem);
        //}
        item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + offset;
        CurrItem = item;
        CurrItem.GetComponent<DraggableInventoryItem>().itemSlot = this;
    }
    internal void DeleteItem()
    {
        currItem = null;
    }


    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    selected = !selected;
    //    if(selected)
    //    {
    //        gameObject.GetComponent<Image>().color = Color.blue;
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Image>().color = Color.white;
    //    }
    //}
}
