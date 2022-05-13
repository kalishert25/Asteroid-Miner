using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : StorageObject
{
    [SerializeField]
    private List<InventoryItemData> itemTypes;
    [SerializeField]
    private StorageObject player;
    private void Start()
    {
        float scaleFactor = Random.Range(0.7f, 1.7f);
        float theta = Random.Range(0f, 4f);
        gameObject.transform.eulerAngles = Vector3.forward * theta * 90f;
        gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        foreach (InventoryItemData item in itemTypes)
        {
            inventory.Add(item, 50);
        }
        
    }
    public List<Sprite> sprites;
    public void onHandleMine()
    {
        if(inventory.ToList().Count <= 0)
        {
            ProximitySpawner.gameObjects.Remove(this.gameObject);
            Destroy(this.gameObject);
            return;
        }
        itemTypes = inventory.GetItemTypes();
        InventoryItemData itemToMine = itemTypes[Random.Range(0, itemTypes.Count)];
        TrasferItems(player, itemToMine);
    }
}


