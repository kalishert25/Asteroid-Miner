using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ModalInventoryUI : MonoBehaviour
{
    public int slotCount;
    [SerializeField]
    private GameObject m_slotPrefab;
    [SerializeField]
    private GameObject m_draggableItemPrefab;
    [SerializeField]
    private StorageObject player;
    void Awake()  
    {
        DrawInventory();
        player.inventory.OnItemAdd += OnItemAddInventory;
        player.inventory.OnItemRemove += OnItemRemoveInventory;
        player.inventory.OnStackModified += OnStackModifiedInventory;
    }

    private void OnStackModifiedInventory()
    {
        foreach(Transform t in transform)
        {
            if (t.gameObject.GetComponent<ItemSlot>().CurrItem == null) 
            {
                continue; 
            }
            if (t.gameObject.GetComponent<ItemSlot>().CurrItem.GetComponent<DraggableInventoryItem>().ItemValue.data == player.inventory.LastModified.data)
            {
                t.gameObject.GetComponent<ItemSlot>().CurrItem.GetComponent<DraggableInventoryItem>().ItemValue = (player.inventory.LastModified);
                return;
            }
        }
    }

    private void OnItemAddInventory()
    {
        foreach (Transform t in transform)
        {
            if (t.gameObject.GetComponent<ItemSlot>().CurrItem == null)
            {
                GameObject newItem = Instantiate(m_draggableItemPrefab);
                newItem.transform.SetParent(this.transform.parent);
                newItem.GetComponent<DraggableInventoryItem>().ItemValue = (player.inventory.LastModified);
                t.gameObject.GetComponent<ItemSlot>().Put(newItem);
                return;
            }
        }
    }

    private void OnItemRemoveInventory()
    {
        foreach (Transform t in transform)
        {
            if (t.gameObject.GetComponent<ItemSlot>().CurrItem.GetComponent<DraggableInventoryItem>().ItemValue.data == player.inventory.LastModified.data)
            {
                Destroy(t.gameObject);
                return;
            }
        }
    }

    public void DrawInventory()
    {
        for (int i = 0; i < slotCount; i++)
        {
            AddInventorySlot();
        }   
    }
    public void AddInventorySlot()
    {
        GameObject newSlot = Instantiate(m_slotPrefab);
        newSlot.transform.SetParent(transform, false);
    }
}
