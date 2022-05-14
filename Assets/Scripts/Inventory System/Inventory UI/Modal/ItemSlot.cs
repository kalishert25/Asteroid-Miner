using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IDropHandler, IEndDragHandler
{
    private GameObject currItem;
    private Vector2 offset;

    public GameObject CurrItem { get => currItem; private set => currItem = value; }

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

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
