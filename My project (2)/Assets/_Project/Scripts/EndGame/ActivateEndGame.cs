using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateEndGame : MonoBehaviour
{
    public GameObject endPanel;
    private void OnTriggerEnter(Collider other)
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
