using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonSwitch : MonoBehaviour
{
    // Скрипт меняет картинку на кнопке
    private Button level;
    private string imgPath = "Assets/Screenshots/lvl_";
    public int numLvl;
    public static Func<int, Sprite> onGetedImg;
    private void Start()
    {
        var img = transform.GetChild(1).gameObject.GetComponent<Image>();
        // img.sprite = LoadTexture2Sprite(numLvl);
        img.sprite = onGetedImg?.Invoke(numLvl);
    }
}
