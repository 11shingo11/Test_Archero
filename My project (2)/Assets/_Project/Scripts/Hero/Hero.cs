using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int maxHp;
    public int currHp;
    
    
    [SerializeField] private Weapon weapon;

    private float lastShootingTime;

    private void Awake()
    {
        lastShootingTime = Time.time;
    }
    private void FixedUpdate()
    {
        weapon.FindNearestTarget();
        weapon.Shoot();
    }
    
}

    