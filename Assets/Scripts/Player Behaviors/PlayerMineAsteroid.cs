using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMineAsteroid : MonoBehaviour
{
    public KeyCode mineKey;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Stared Mining Script");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (Input.GetKeyDown(mineKey)) {
            Debug.Log("Mining");
        }
        //collision.articulationBody.GetComponent<StorageObjectPointer>().IntanceRef.TrasferItems();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
