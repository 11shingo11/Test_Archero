using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementLimiter : MonoBehaviour
{

    public bool isOn = true;


    [SerializeField] private CameraBounds Bounds; 

    private void FixedUpdate()
    {
        if (!isOn) return;
        LimitObjectBounds();
    }

    private void LimitObjectBounds() 
    {
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, Bounds.xLeft, Bounds.xRight);
        transform.position = clampedPos;
    }
}
