using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public int currHp;
    public int damage = 1;
    [SerializeField] private Projectile dmg;
    public float movementSpeed = 3f; // —корость перемещени€ врага
    public float detectionRange = 5f; // ƒальность обнаружени€ игрока
    public float retreatDistance = 2f; // ƒистанци€ отхода врага

    private Transform player; // —сылка на трансформ игрока
    private Vector3 lastKnownPlayerPosition; // ѕоследнее известное местоположение игрока
    private Vector3 targetPosition; // ÷елева€ позици€ дл€ перемещени€
    public bool dead = false;
    [SerializeField] private Player playerGold;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Ќаходим игрока по тегу
        targetPosition = transform.position;
        lastKnownPlayerPosition = player.position; // Ќачальное значение последнего известного местоположени€ игрока
    }

    private void Update()
    {
        // ѕровер€ем, видим ли игрока
        bool canSeePlayer = CanSeePlayer();

        if (canSeePlayer)
        {
            // ≈сли видим игрока, то двигаемс€ к его позиции и обновл€ем последнее известное местоположение
            Vector3 directionToPlayer = player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(-directionToPlayer.x, 0, -directionToPlayer.z));

            lastKnownPlayerPosition = player.position;
            targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z); // —охран€ем только горизонтальные координаты
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
        else
        {
            // ≈сли игрока не видим, то перемещаемс€ к последнему известному местоположению
            targetPosition = new Vector3(lastKnownPlayerPosition.x, transform.position.y, lastKnownPlayerPosition.z); // —охран€ем только горизонтальные координаты
        }

        // ƒвигаемс€ к целевой позиции
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    private bool CanSeePlayer()
    {
        // ѕровер€ем, есть ли пр€ма€ видимость на игрока
        Vector3 directionToPlayer = player.position - transform.position;
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

    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// </summary>
    private void Start()
    {
        currHp = maxHp;
        playerGold = FindObjectOfType<Camera>().GetComponent<Player>();
    }

    public void RecieveDamage()
    {
        if (currHp - dmg.damage > 0) currHp -= dmg.damage;
        else if (!dead) Death();
        else return;
        //Debug.Log("you Recirve" + " " + dmg.damage.ToString());
    }

    public void Death()
    {
        dead = true;
        Destroy(gameObject);
        playerGold.GainGold();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.ToString());
        if (other.gameObject.name == "Hero")
            other.gameObject.GetComponent<Hero>().ReciveDamage(this);
        if (other.gameObject.name == "Projectile(Clone)")
            RecieveDamage();
    }

    private void OnShootingPosition()
    {

    }
}


