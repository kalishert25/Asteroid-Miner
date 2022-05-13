using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public abstract class StorageObject : MonoBehaviour
{

    public InventorySystem inventory = new();
    private void Start() 
    {
        
    }

    public void TrasferItems(StorageObject targetInventory, InventoryItemData referenceData, int quantity = 1)
    {

        inventory.Remove(referenceData, quantity);
        targetInventory.inventory.Add(referenceData);

    }
    
}
