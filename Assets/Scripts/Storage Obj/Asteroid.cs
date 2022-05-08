using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : StorageObject
{
    public Asteroid(Vector2 position, Sprite sprite, float rotationAngle, float scaleFactor) 
        : base(position, sprite, rotationAngle, scaleFactor)
    {
        Debug.Log(rotationAngle);
    }

}

