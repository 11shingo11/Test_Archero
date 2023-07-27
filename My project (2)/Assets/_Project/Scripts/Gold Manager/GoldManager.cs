using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour 
{
    public int gold;
    public TextMeshProUGUI textMeshPro;

    public void GainGold()
    {
        gold += 10;
        textMeshPro.text = $"Gold: {gold}";
    }
}
