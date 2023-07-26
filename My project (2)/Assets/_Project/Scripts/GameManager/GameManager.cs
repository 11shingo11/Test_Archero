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
        // ��������� �������� � ��������
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
            currentTime += Time.unscaledDeltaTime; // ���������� unscaledDeltaTime ��� ������� ��� ����� Time.timeScale
            yield return null;
        }

        isCountdownOver = true;

        // ���������� ���������� �������
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

