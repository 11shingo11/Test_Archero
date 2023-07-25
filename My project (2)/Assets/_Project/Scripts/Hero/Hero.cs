using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int maxHp;
    public int currHp;
    public float attackSpeed;
    public int damage;

    [SerializeField] private HeroController controller;

    private float lastShootingTime;

    private void Awake()
    {
        lastShootingTime = Time.time;
    }
    private void FixedUpdate()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (!controller.isMoving && Time.time - lastShootingTime >= attackSpeed)
        {
            lastShootingTime = Time.time;
            Debug.Log("Shoot");
        }
    }
}

