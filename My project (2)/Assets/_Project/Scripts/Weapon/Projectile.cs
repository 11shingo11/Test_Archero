using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Скорость полета снаряда
    public int damage = 1;
    private Enemy enemy;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {    
        Destroy(gameObject);
    }

 
}
