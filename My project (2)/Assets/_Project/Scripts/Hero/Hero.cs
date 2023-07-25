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
        currHp = maxHp;
    }
    private void FixedUpdate()
    {
        weapon.FindNearestTarget();
        weapon.Shoot();
    }
    
    public void ReciveDamage(Enemy enemy)
    {
        if (currHp - enemy.damage > 0) currHp -= enemy.damage;
        //else Death();
        Debug.Log("Hero Recirve" + " " + enemy.damage.ToString());
    }
}

    