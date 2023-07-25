using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float zOffset = -10f; // Отступ камеры по оси Z

    private void Update()
    {
        // Получаем текущую позицию камеры
        Vector3 currentPosition = transform.position;

        // Устанавливаем позицию камеры по оси Z в соответствии с позицией игрока
        currentPosition.z = player.position.z + zOffset;

        // Обновляем позицию камеры
        transform.position = currentPosition;
    }
}

