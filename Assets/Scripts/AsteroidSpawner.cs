using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public GameObject baseAsteroid;
    public int NUMBER_OF_ASTEROIDS = 10;
    public readonly (float, float) BOUNDS = (60f, 40f);
    private List<GameObject> asteroids;
    // Start is called before the first frame update
    void Start() {
        asteroids = new List<GameObject>();
        for (int i = 0; i < NUMBER_OF_ASTEROIDS; i++) {
            SpawnAsteroid();
        }
    }

    // Update is called once per frame
    private void SpawnAsteroid() {
        float xCoord = Random.Range(-BOUNDS.Item1, BOUNDS.Item1);
        float yCoord = Random.Range(-BOUNDS.Item2, BOUNDS.Item2);
        float theta = Random.Range(0, 4);
        GameObject newAsteroid = Instantiate(baseAsteroid);
        newAsteroid.transform.position = new Vector3(xCoord, yCoord, 0);
        newAsteroid.transform.eulerAngles = Vector3.forward * theta * 90;
        asteroids.Add(newAsteroid);
    }

}
