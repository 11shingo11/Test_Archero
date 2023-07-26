using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    private float lastShootingTime;
    public float attackSpeed;
    [SerializeField] private HeroController controller;
    
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectilePos;
    
    public void Shoot()
    {
        if (!controller.isMoving && Time.time - lastShootingTime >= attackSpeed)
        {

            GameObject newProjectile = Instantiate(projectilePrefab, projectilePos.position , transform.rotation);
            lastShootingTime = Time.time;
            //Debug.Log("Shoot");
        }
    }

    public void FindNearestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();


        if (enemies.Length > 0)
        {
            // Находим ближайшего врага
            Enemy nearestEnemy = null;
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

            // Поворачиваемся к ближайшему врагу
            if (nearestEnemy != null)
            {
                Vector3 directionToEnemy = (nearestEnemy.transform.position - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToEnemy.x, 0f, directionToEnemy.z));
                transform.rotation = targetRotation;
            }
        }
    }
}
