using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideModal : MonoBehaviour
{
    [SerializeField]
    private KeyCode OpenCloseInventoryKey;
    private bool isActive = false;
    private Transform modal;
    private void Awake()
    {
        modal = gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        modal.localPosition = new Vector2(10000, 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(OpenCloseInventoryKey))
        {
            isActive = !isActive;
            if (isActive)
            {
                //Time.timeScale = 0;
                modal.localPosition = new Vector2(0, 0);
            }
            else
            {
                //Time.timeScale = 1;
                modal.localPosition = new Vector2(10000, 0);
            }

        }
    }
}
