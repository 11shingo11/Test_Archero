using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform planeTransform;
    [SerializeField][Tooltip("����� ������� �������� �� ���� ������")] private float offset = 1;
    public float xLeft;
    public float xRight;

    private void Awake()
    {
        if (!cam) cam = Camera.main;
    }

    private void OnDrawGizmos()
    {
        DrawCameraBounds();
    }

    private void DrawCameraBounds()
    {
        if (!cam) cam = Camera.main;
        if (cam == null) return;

        var camTransform = cam.transform;
        var cameraToObject = planeTransform.position - camTransform.position;

        // ��������� ������ ��� ������� ������� � ������ ������ ��������� ���� ������ �� ��� y
        float distance = -Vector3.Project(cameraToObject, camTransform.forward).y;

        // ������� "�����" �������� ��������� ������ �� ����������� ���������� �� ������
        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightBot = cam.ViewportToWorldPoint(new Vector3(1, 0, distance));

        // ������� � ��������� XZ, �.�. ������ ����� ���� ��������� ��������
        xLeft = leftBot.x + offset;
        xRight = rightBot.x - offset;


    }
}

