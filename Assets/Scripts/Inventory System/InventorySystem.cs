using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    private Dictionary<InventoryItemData, InventoryItem> m_item_dictionary;
    public List<InventoryItem> inventory {get; private set; }

    public InventorySystem()
    {
        inventory = new List<InventoryItem>();
        m_item_dictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
    public void Add(InventoryItemData referenceData)
    {
        if(m_item_dictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_item_dictionary.Add(referenceData, newItem);
        }
    }
    public void Remove(InventoryItemData referenceData)
    {
        if (m_item_dictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_item_dictionary.Remove(referenceData);
            }
        }
    }
    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_item_dictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
    public List<InventoryItemData> GetItemTypes()
    {
        return new List<InventoryItemData>(m_item_dictionary.Keys);
    }
}
