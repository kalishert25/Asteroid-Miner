using System;

using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    public float spawnRadius, minSpacing, secondsBetweenSpawning;
    public List<Sprite> sprites;
    private List<GameObject> asteroids;
    private float currSpawnAngle;
    private Vector2 currSpawnPos;
    
    void Start()
    {
        asteroids = new List<GameObject>();
        StartCoroutine("TryToSpawnAsteroid");

    }
    IEnumerator TryToSpawnAsteroid()
    {
        for (;;)
        {
            currSpawnAngle = Random.Range(0, 2 * Mathf.PI);
            currSpawnPos.x = spawnRadius * Mathf.Cos(currSpawnAngle) + player.position.x;
            currSpawnPos.y = spawnRadius * Mathf.Sin(currSpawnAngle) + player.position.y;
            if (asteroids.Select(a => ((Vector2) a.transform.position - currSpawnPos).magnitude).All(m => m > minSpacing))
            { // checks if the asteroid is far enough away from other asteroids
                CreateAsteroid();
            }
            
            yield return new WaitForSeconds(secondsBetweenSpawning);
        }
    }

    
    private void CreateAsteroid()
    {
        float scaleFactor = Random.Range(0.7f, 1.7f);
        float theta = Random.Range(0f, 4f);
        //Asteroid newAsteroid = new Asteroid(currSpawnPos, , theta * 90f, scaleFactor);
        GameObject newAsteroid = Instantiate(prefab);
        newAsteroid.AddComponent<Asteroid>();
        newAsteroid.transform.position = currSpawnPos;
        newAsteroid.transform.eulerAngles = Vector3.forward * theta * 90f;
        newAsteroid.transform.localScale = new Vector3(scaleFactor, scaleFactor, 0);
        newAsteroid.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        asteroids.Add(newAsteroid);
    }

}
