using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : StorageObject {
    public KeyCode mineKey;
    public Slider fuelBar, healthBar;
    public float maxHealth, maxFuel, passiveFuelLoss, fuelLossWhileMoving;
    private float hp, fp;


    [SerializeField]
    private float speed, passiveMovementSpeed;
    [SerializeField]
    private float rotationSpeed;
    private Vector2 drift;
    public Animator animator;

    void Start() {
        drift = Vector2.zero;
        hp = maxHealth;
        fp = maxFuel;
        fuelBar.maxValue = maxFuel;
        healthBar.maxValue = maxHealth;
    }

    void FixedUpdate() {
        // passive fuel loss
        fp -= passiveFuelLoss;
        fuelBar.value = (float)fp;
        healthBar.value = hp;

        //movement
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector3(inputX, inputY);
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();
        movement *= Time.deltaTime;
        transform.Translate(movement * speed * inputMagnitude * Time.deltaTime, Space.World);
        animator.SetFloat("Speed", Mathf.Abs(movement.magnitude));

        if (movement != Vector2.zero) {
            drift = movement;
            fp -= fuelLossWhileMoving;
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(drift * passiveMovementSpeed * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Hitting");
        if (Input.GetKey(mineKey))
        {
            collision.gameObject.GetComponent<Asteroid>().onHandleMine();
        }
    }
}
