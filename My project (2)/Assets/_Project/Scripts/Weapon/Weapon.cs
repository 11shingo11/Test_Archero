using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectilePos;

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, projectilePos.position, transform.rotation);
    }
}

    

