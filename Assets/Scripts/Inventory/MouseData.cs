using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseData : MonoBehaviour
{
    public Image menuSprite;
    public TextMeshProUGUI itemCounter;

    private void Awake(){
        menuSprite.color = Color.clear;
        itemCounter.text = "";
    }
}
