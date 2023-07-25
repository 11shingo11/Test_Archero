using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public int currHp;
    [SerializeField] private Projectile dmg;

    private void Start()
    {
        currHp = maxHp;
    }

    public void RecieveDamage()
    {
        if (currHp-dmg.damage > 0) currHp -= dmg.damage;
        else Death();
        Debug.Log("you Recirve" + " " + dmg.damage.ToString());
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
