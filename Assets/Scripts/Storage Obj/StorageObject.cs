using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class StorageObject : MonoBehaviour
{
    private InventorySystem inventory { get; set; }
    public void Start()
    {
        inventory = new InventorySystem();
        //gameObject.GetComponent<PolygonCollider2D>().SetPath(0, gameObject.GetComponent<SpriteRenderer>().sprite.vertices);
    }
     
    public void TrasferItems(StorageObject targetInventory, InventoryItemData referenceData, int quantity=1)
    {
        for (int i = 0; i < quantity; i ++)
        {
            inventory.Remove(referenceData);
            targetInventory.inventory.Add(referenceData);
        }
    }
}
