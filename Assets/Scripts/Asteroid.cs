using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid
{
    public GameObject prefab;
    private InventorySystem inventory;
    public Asteroid(GameObject prefab)
    {
        inventory = new InventorySystem();
        this.prefab = prefab;

    }
    private void generateItems()
    {

    }
    private void fillInventory(List<InventoryItem> items)
    {
        foreach (InventoryItem item in items)
        {
            for (int i = 0; i < item.stackSize; i++)
            {
                inventory.Add(item.data);
            }

        }
    }
}

