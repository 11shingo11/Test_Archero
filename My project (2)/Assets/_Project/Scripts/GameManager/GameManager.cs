using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public HeroController playerController;
    private bool isCountdownOver = false;
    public int countEnemys;
    public GameObject endPlane;
    public GameObject pointer;


    private void Start()
    {
        countEnemys = enemySpawner.numberOfEnemies;
        StartCoroutine(StartGameWithDelay());
    }

    private IEnumerator StartGameWithDelay()
    {
        enemySpawner.SpawnEnemiesWithDelay();
        Time.timeScale = 0;
        float countdownDuration = 3f;
        float currentTime = 0f;

        while (currentTime < countdownDuration)
        {
            currentTime += Time.unscaledDeltaTime; 
            yield return null;
        }

        isCountdownOver = true;

        playerController.enabled = true;
    }

    private void Update()
    {
        if (isCountdownOver)
        {
            Time.timeScale = 1;
            isCountdownOver = false;
        }
        else return;
    }

    public void EndGame()
    {
        if (countEnemys == 0)
        {
            endPlane.SetActive(true);
            pointer.SetActive(true);
        }
        else return;
    }
}



