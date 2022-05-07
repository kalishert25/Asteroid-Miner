using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public List<Sprite> sprites;
    public int NUMBER_OF_ASTEROIDS = 10;
    public readonly (float, float) BOUNDS = (60f, 40f);
    private List<GameObject> asteroids;
    // Start is called before the first frame update
    void Start()
    {
        asteroids = new List<GameObject>();
        for (int i = 0; i < NUMBER_OF_ASTEROIDS; i++)
        {
            SpawnAsteroid();
        }
    }

    // Update is called once per frame
    private void SpawnAsteroid()
    {
        float scaleFactor = Random.Range(0.7f, 1.7f);
        float xCoord = Random.Range(-BOUNDS.Item1, BOUNDS.Item1);
        float yCoord = Random.Range(-BOUNDS.Item2, BOUNDS.Item2);
        float theta = Random.Range(0f, 4f);
        GameObject newAsteroid = Instantiate(asteroid);
        newAsteroid.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        newAsteroid.transform.position = new Vector3(xCoord, yCoord, 0);
        newAsteroid.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        newAsteroid.transform.eulerAngles = Vector3.forward * theta * 90;
        asteroids.Add(newAsteroid);
    }

}
