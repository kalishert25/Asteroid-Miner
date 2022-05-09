using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : StorageObject
{
    private void Start()
    {
        float scaleFactor = Random.Range(0.7f, 1.7f);
        float theta = Random.Range(0f, 4f);
        gameObject.transform.eulerAngles = Vector3.forward * theta * 90f;
        gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];

    }
    public List<Sprite> sprites;
    //public void Mine()
    //{
    //   items
    //   base.TrasferItems()
    //}
    private void CreateAsteroid()
    {

    }
}


