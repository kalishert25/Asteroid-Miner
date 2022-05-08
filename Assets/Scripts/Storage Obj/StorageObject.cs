using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class StorageObject
{
    public GameObject gameObject {get; set;}
    private InventorySystem inventory { get; set; }
    public StorageObject(Vector2 position, Sprite sprite, float rotationAngle, float scaleFactor)
    {
        
        gameObject = new GameObject("Asteroid");
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<PolygonCollider2D>();
        gameObject.AddComponent<StorageObjectPointer>();

        gameObject.GetComponent<PolygonCollider2D>().SetPath(0, sprite.vertices);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        gameObject.GetComponent<StorageObjectPointer>().IntanceRef = this;
        gameObject.transform.position = position;
        gameObject.transform.eulerAngles = Vector3.forward * rotationAngle;
        gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        inventory = new InventorySystem();
    }
     
    public void TrasferItems(StorageObject targetInventory, InventoryItemData referenceData, int quantity=1)
    {
        for (int i = 0; i < quantity; i ++)
        {
            inventory.Remove(referenceData);
            targetInventory.inventory.Add(referenceData);
        }
    }
    public Vector2 Position()
    {
        return gameObject.transform.position;
    }



}
