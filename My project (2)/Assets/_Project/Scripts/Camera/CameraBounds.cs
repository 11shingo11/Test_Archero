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
    public float zTop;
    public float zBot;

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

        float distance = -Vector3.Project(cameraToObject, camTransform.forward).y;

        var leftTop = cam.ViewportToWorldPoint(new Vector3(0, 1, distance));
        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightBot = cam.ViewportToWorldPoint(new Vector3(1, 0, distance));
        var rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        xLeft = leftBot.x + offset;
        xRight = rightTop.x - offset;
        zBot = leftBot.z + offset;
        zTop = rightTop.z - offset;
#if UNITY_EDITOR
        Gizmos.DrawLine(leftBot, leftTop);
        Gizmos.DrawLine(leftBot, rightBot);
        Gizmos.DrawLine(rightBot, rightTop);
        Gizmos.DrawLine(leftTop, rightTop);
#endif

    }
}

