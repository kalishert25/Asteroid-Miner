using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMineAsteroid : MonoBehaviour
{
    public KeyCode mineKey;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started Mining Script");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(mineKey))
        {
            
        }
        //collision.articulationBody.GetComponent<StorageObjectPointer>().IntanceRef.TrasferItems();
    }
}
