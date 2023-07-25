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
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (other.gameObject.name == "Enemy")
            other.gameObject.GetComponent<Enemy>().RecieveDamage(); ;
            

        Destroy(gameObject);
    }

 
}
