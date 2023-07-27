using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public int numberOfEnemies = 5;
    [SerializeField] private Transform spawnTransform;
    public CameraBounds Bounds;
    


    public void SpawnEnemiesWithDelay()
    { 

        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            float originalY = enemyPrefab.transform.position.y;
            float randomX = Random.Range(Bounds.xLeft, Bounds.xRight);
            float randomZ = Random.Range(Bounds.zBot + 10, Bounds.zTop + 10);
            Vector3 spawnPosition = new Vector3(randomX, originalY, randomZ);
            var obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, spawnTransform);
        }
    }

}
