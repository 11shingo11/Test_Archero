using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public FixedJoystick joystick; // Ссылка на джойстик
    public bool isMoving;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        OnHeroMove();
        if(_rb.velocity == Vector3.zero)
            isMoving = false;
    }
    private void OnHeroMove()
    {
        _rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, _rb.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        isMoving = true;
    }
}