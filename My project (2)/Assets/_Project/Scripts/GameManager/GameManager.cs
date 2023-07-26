using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public HeroController playerController;
    private bool isCountdownOver = false;

    private void Start()
    {
        // Запускаем корутину с отсчетом
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
            currentTime += Time.unscaledDeltaTime; // Используем unscaledDeltaTime для отсчета без учета Time.timeScale
            yield return null;
        }

        isCountdownOver = true;

        // Активируем управление игроком
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
}

