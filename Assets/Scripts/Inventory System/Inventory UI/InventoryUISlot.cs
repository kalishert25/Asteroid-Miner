using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    [SerializeField]
    private Image m_icon;
    [SerializeField]
    private GameObject m_stackObj;
    [SerializeField]
    private TextMeshProUGUI m_stackLabel;
    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        if(item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_stackLabel.text = item.stackSize.ToString();
    }

}
