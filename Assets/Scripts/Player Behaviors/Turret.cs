using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 mousePos, lookDir;
    private float angle;

    void FixedUpdate()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }
}
