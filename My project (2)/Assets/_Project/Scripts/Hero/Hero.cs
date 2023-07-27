using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


interface IDamageble
{
    void ReciveDamage(int dmg);
}
public class Hero : MonoBehaviour , IDamageble
{
    private int maxHp = 10;
    private int currHp;
    private Enemy nearestEnemy = null;
    private float lastShootingTime;
    public float attackCooldown = 2;
    [SerializeField] private Weapon weapon;
    [SerializeField] private HeroController controller;



    private void Awake()
    {
        currHp = maxHp;
    }
    private void FixedUpdate()
    {
        FindNearestTarget();
        LookAtEnemy(nearestEnemy);
        if (!controller.isMoving && Time.time - lastShootingTime >= attackCooldown)
        {
            weapon.Shoot();
            lastShootingTime = Time.time;
        }
    }

    public void ReciveDamage(int dmg)
    {
        if (currHp - dmg > 0)
        {
            currHp -= dmg;
        }
        else
        {
            // Можно добавить здесь логику для обработки смерти игрока
            Debug.Log("Hero died!");
        }
    }

    public Enemy FindNearestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();//затратный метод, вместо него нужно использовать кэширование 


        if (enemies.Length > 0)
        {
            float nearestDistance = Mathf.Infinity;
            foreach (Enemy enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < nearestDistance)
                {
                    nearestEnemy = enemy;                   
                    nearestDistance = distanceToEnemy;                    
                }                
            }
            return nearestEnemy;
        }
        else return null;
    }

    public void LookAtEnemy(Enemy targetEnemy)
    {
        if (targetEnemy != null)
        {
            Vector3 directionToEnemy = (targetEnemy.transform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToEnemy.x, 0f, directionToEnemy.z));
            transform.rotation = targetRotation;
        }    
    }
}

