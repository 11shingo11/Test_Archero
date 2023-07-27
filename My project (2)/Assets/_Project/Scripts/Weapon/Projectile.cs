using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; 
    public int damage = 1;


    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {    
        if(other.TryGetComponent<IDamageble>(out IDamageble damageble))
            damageble.ReciveDamage(damage);
        Destroy(gameObject);
    }

 
}
