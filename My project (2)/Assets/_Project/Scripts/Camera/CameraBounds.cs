using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform planeTransform;
    [SerializeField][Tooltip("Офсет позиции объектов от края камеры")] private float offset = 1;
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

        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, camTransform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightBot = cam.ViewportToWorldPoint(new Vector3(1, 0, distance));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        xLeft = leftBot.x + offset;
        xRight = rightBot.x - offset;


    }
}

