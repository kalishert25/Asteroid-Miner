using System;

using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    
    public Transform player;
    public float spawnRadius, minSpacing, secondsBetweenSpawning;
    public List<Sprite> sprites;
    private List<Asteroid> asteroids;
    private float currSpawnAngle;
    private Vector2 currSpawnPos;
    
    void Start()
    {
        asteroids = new List<Asteroid>();
        CreateAsteroid();
        StartCoroutine("TryToSpawnAsteroid");

    }
    IEnumerator TryToSpawnAsteroid()
    {
        for (;;)
        {
            currSpawnAngle = Random.Range(0, 2 * Mathf.PI);
            currSpawnPos.x = spawnRadius * Mathf.Cos(currSpawnAngle) + player.position.x;
            currSpawnPos.y = spawnRadius * Mathf.Sin(currSpawnAngle) + player.position.y;
            Debug.Log((asteroids.Select(a => (a.Position() - currSpawnPos).magnitude).All(m => m > minSpacing)));
            if (asteroids.Select(a => (a.Position() - currSpawnPos).magnitude).All(m => m > minSpacing))
            { // checks if the asteroid is far enough away from other asteroids
                CreateAsteroid();
            }
            
            yield return new WaitForSeconds(secondsBetweenSpawning);
        }
    }

    
    private void CreateAsteroid()
    {
        Debug.Log("Created an asteroid");
        float scaleFactor = Random.Range(0.7f, 1.7f);
        float theta = Random.Range(0f, 4f);
        Asteroid newAsteroid = new Asteroid(currSpawnPos, sprites[Random.Range(0, sprites.Count)], theta * 90f, scaleFactor);
        asteroids.Add(newAsteroid);
    }

}
