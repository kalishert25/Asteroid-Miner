using System;

using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{

    public float spawnRadius, minSpacing;
    public List<Sprite> sprites;
    private List<Asteroid> asteroids;
    private Vector2 currSpawnLocation;

    void Start()
    {
        asteroids = new List<Asteroid>();

    }
    private void Update()
    {

        asteroids.Select(a => a.Position());
    }

    private void SpawnAsteroid()
    {
        float scaleFactor = Random.Range(0.7f, 1.7f);
        float xCoord = Random.Range(-10, 10);
        float yCoord = Random.Range(-10, 10);
        float theta = Random.Range(0f, 4f);
        Asteroid newAsteroid = new Asteroid(new Vector2(xCoord, yCoord), sprites[Random.Range(0, sprites.Count)], theta * 90f, scaleFactor);
        asteroids.Add(newAsteroid);
    }

}
