using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
    public int gold;
    public TextMeshProUGUI textMeshPro;


    private void FixedUpdate()
    {
        textMeshPro.text = $"Gold: {gold}";
    }
    public void GainGold()
    {
        Debug.Log("gain gold");
        gold += 10;
    }
}
