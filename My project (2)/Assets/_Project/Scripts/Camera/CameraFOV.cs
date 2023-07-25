using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{

    public bool isOn = true;


    [SerializeField] private CameraBounds Bounds; 

    private void FixedUpdate()
    {
        if (!isOn) return;
        LimitObjectBounds();
    }

    private void LimitObjectBounds() //Для ограничения позиции объекта внутри поле зрения камеры
    {
        // ограничиваем объект в плоскости XZ
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, Bounds.xLeft, Bounds.xRight);
        //clampedPos.z = Mathf.Clamp(clampedPos.z, Bounds.zBot, Bounds.zTop);
        transform.position = clampedPos;
    }
}
