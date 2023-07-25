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
    public float movementSpeed = 3f; // �������� ����������� �����
    public float detectionRange = 5f; // ��������� ����������� ������
    public float retreatDistance = 2f; // ��������� ������ �����

    private Transform player; // ������ �� ��������� ������
    private Vector3 lastKnownPlayerPosition; // ��������� ��������� �������������� ������
    private Vector3 targetPosition; // ������� ������� ��� �����������

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
        targetPosition = transform.position;
        lastKnownPlayerPosition = player.position; // ��������� �������� ���������� ���������� �������������� ������
    }

    private void Update()
    {
        // ���������, ����� �� ������
        bool canSeePlayer = CanSeePlayer();

        if (canSeePlayer)
        {
            // ���� ����� ������, �� ��������� � ��� ������� � ��������� ��������� ��������� ��������������
            lastKnownPlayerPosition = player.position;
            targetPosition = player.position;
        }
        else
        {
            // ���� ������ �� �����, �� ������������ � ���������� ���������� ��������������
            targetPosition = lastKnownPlayerPosition;
        }

        // ��������� � ������� �������
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    private bool CanSeePlayer()
    {
        // ���������, ���� �� ������ ��������� �� ������
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
    }

    public void RecieveDamage()
    {
        if (currHp - dmg.damage > 0) currHp -= dmg.damage;
        else Death();
        Debug.Log("you Recirve" + " " + dmg.damage.ToString());
    }

    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (other.gameObject.name == "Hero")
            other.gameObject.GetComponent<Hero>().ReciveDamage(this);
    } 
}


