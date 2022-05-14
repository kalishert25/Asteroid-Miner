using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IDropHandler, IEndDragHandler
{
    bool isOccupied = false;
    private Vector2 offset;
    private void Start()
    {
        Debug.Log(gameObject.transform.parent);
        offset = gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition;
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        if (eventData.pointerDrag != null)
        {
            Debug.Log(offset);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + offset; 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
