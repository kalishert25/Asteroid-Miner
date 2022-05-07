using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector3(inputX, inputY);
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();
        movement *= Time.deltaTime;
        transform.Translate(movement * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (movement != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
