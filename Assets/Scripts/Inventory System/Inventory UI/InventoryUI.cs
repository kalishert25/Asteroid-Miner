using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public int slotCount;
    [SerializeField]
    private GameObject m_slotPrefab;
    [SerializeField]
    private StorageObject player;
    void Awake()
    {
        DrawInventory();
        player.inventory.OnModified += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
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
        ItemSlot slot = newSlot.GetComponent<ItemSlot>();
    }
}
