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

            // Получаем Y-позицию из префаба
            float originalY = enemyPrefab.transform.position.y;

            // Получаем случайные X и Z-позиции внутри заданной области
            float randomX = Random.Range(Bounds.xLeft, Bounds.xRight);
            float randomZ = Random.Range(Bounds.zBot + 10, Bounds.zTop + 10);

            // Создаем новый Vector3 с сохраненным Y и случайными X и Z-позициями
            Vector3 spawnPosition = new Vector3(randomX, originalY, randomZ);

            // Создаем экземпляр префаба на заданной позиции
            var obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, spawnTransform);
        }
    }
    
    //public Vector3 RandomPosition()
    //{
    //    // ограничиваем объект в плоскости XZ
    //    var clampedPos = new Vector3(Random.Range(Bounds.xLeft, Bounds.xRight), Random.Range(0.6f, 2),
    //        Random.Range(Bounds.zBot+10, Bounds.zTop+10));
    //    return clampedPos;
    //}

}
