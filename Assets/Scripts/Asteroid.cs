using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : StorageObject
{
    public Asteroid(Vector2 position, Sprite sprite, float rotationAngle = 0, float scaleFactor = 1) 
        : base(position, sprite, rotationAngle = 0, scaleFactor = 1)
    { }

}

