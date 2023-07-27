using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;


    public void ToggleMenu()
    {
        bool isMenuActive = !menuPanel.activeSelf;
        menuPanel.SetActive(isMenuActive);
        Time.timeScale = isMenuActive ? 0f : 1f;
    }
}


