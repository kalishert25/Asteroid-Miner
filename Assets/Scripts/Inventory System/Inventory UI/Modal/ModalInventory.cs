using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject m_slotPrefab;
    [SerializeField]
    private StorageObject player;
    void Awake()
    {
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
        foreach (InventoryItem item in player.inventory.ToList())
        {
            AddInventorySlot(item);
        }
    }
    public void AddInventorySlot(InventoryItem item)
    {
        GameObject newSlot = Instantiate(m_slotPrefab);
        newSlot.transform.SetParent(transform, false);
        InventoryUISlot slot = newSlot.GetComponent<InventoryUISlot>();
        slot.Set(item);
    }
}
