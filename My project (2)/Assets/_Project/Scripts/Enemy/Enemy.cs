using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Enemy : MonoBehaviour, IDamageble
{
    private int maxHp = 2;
    private int currHp;
    public int damage = 1;
    [SerializeField] private Projectile dmg;
    public float movementSpeed = 3f; 
    public float detectionRange = 5f;
    public float retreatDistance = 2f;
    public float rotationSpeed = 5f;
    private Transform player;
    public bool dead = false;
    [SerializeField] private GoldManager playerGold;
    public float stoppingDistance = 10f;
    private Vector3 moveDirection;
    [SerializeField] private Weapon weapon;
    private GameManager gm;
    private float lastShootingTime;
    public float attackCooldown = 2;


    private void Awake()
    {
        lastShootingTime = Time.time;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока по тегу
    }


    private void Update()
    {
        LookAtHero();
        OnShootingPosition();
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position + transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private void LookAtHero()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0f; 
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }


    private void Start()
    {
        currHp = maxHp;
        playerGold = FindObjectOfType<Camera>().GetComponent<GoldManager>();
    }


    public void ReciveDamage(int dmg)
    {
        if (currHp - dmg > 0)
            currHp -= dmg;

        else
        {
            Death();
            Destroy(gameObject);
        }
    }


    public void Death()
    {
        dead = true;
        Destroy(gameObject);
        playerGold.GainGold();
        gm.countEnemys--;
        gm.EndGame();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageble>(out IDamageble damageble) && other.gameObject.name == "Hero")
            damageble.ReciveDamage(damage);
    }


    




    private void OnShootingPosition()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > stoppingDistance)
        {
            moveDirection = transform.forward;

            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }
        else
        {
            if (Time.time - lastShootingTime >= attackCooldown)
            {
                weapon.Shoot();
                lastShootingTime = Time.time;
            }
 
        }
    }
}


