using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public float zOffset = -10f; // ������ ������ �� ��� Z

    private void Update()
    {
        // �������� ������� ������� ������
        Vector3 currentPosition = transform.position;

        // ������������� ������� ������ �� ��� Z � ������������ � �������� ������
        currentPosition.z = player.position.z + zOffset;

        // ��������� ������� ������
        transform.position = currentPosition;
    }
}

