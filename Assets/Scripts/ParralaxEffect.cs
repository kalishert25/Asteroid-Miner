using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxEffect : MonoBehaviour
{

    [SerializeField] private float effectMultiplier;

    private Transform cameraLocation;
    private Vector3 oldCameraLocation, difference, moved;
    private float textureUnitsSizeX, textureUnitsSizeY;

    private void Start()
    {

        cameraLocation = Camera.main.transform;
        oldCameraLocation = cameraLocation.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitsSizeX = texture.width / sprite.pixelsPerUnit * transform.localScale.x;
        textureUnitsSizeY = texture.height / sprite.pixelsPerUnit * transform.localScale.y;


    }

    private void FixedUpdate()
    {

        difference = cameraLocation.position - oldCameraLocation;
        moved = new Vector3(difference.x, difference.y, 0);
        transform.position += moved * effectMultiplier;
        oldCameraLocation = cameraLocation.position;

        if (Mathf.Abs(cameraLocation.position.x - transform.position.x) >= textureUnitsSizeX)
        {

            float offsetPositionX = (cameraLocation.position.x - transform.position.x) % textureUnitsSizeX;
            transform.position = new Vector3(cameraLocation.position.x + offsetPositionX, transform.position.y, transform.position.z);

        }

        if (Mathf.Abs(cameraLocation.position.y - transform.position.y) >= textureUnitsSizeY)
        {

            float offsetPositionY = (cameraLocation.position.y - transform.position.y) % textureUnitsSizeY;
            transform.position = new Vector3(transform.position.x, cameraLocation.position.y + offsetPositionY, transform.position.z);

        }


    }

}
