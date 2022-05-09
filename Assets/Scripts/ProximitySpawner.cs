using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class ProximitySpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;

    public float spawnRadius, minSpacing, secondsBetweenSpawning;
    
    private static List<GameObject> gameObjects;

    private float currSpawnAngle;
    private Vector2 currSpawnPos;
    void Start()
    {
        gameObjects = new();
        gameObjects.Add(prefab);
        StartCoroutine("SpawnObjects");
    }
    IEnumerator SpawnObjects()
    {
        for (; ; )
        {
            
            currSpawnAngle = Random.Range(0, 2 * Mathf.PI);
            currSpawnPos.x = spawnRadius * Mathf.Cos(currSpawnAngle) + player.position.x;
            currSpawnPos.y = spawnRadius * Mathf.Sin(currSpawnAngle) + player.position.y;
            if (gameObjects.Select(a => ((Vector2)a.transform.position - currSpawnPos).magnitude).All(m => m > minSpacing))
            { // checks if the asteroid is far enough away from other asteroids
                GameObject newObject = Instantiate(prefab);
                newObject.transform.position = currSpawnPos;
                newObject.transform.SetParent(this.transform);
                gameObjects.Add(newObject);
            }

            yield return new WaitForSeconds(secondsBetweenSpawning);
        }
    }
}
