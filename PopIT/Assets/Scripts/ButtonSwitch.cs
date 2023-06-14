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
    public int numLvl;
    public static Func<int, Sprite> onGetedImg;
    private void Start()
    {
        var img = transform.GetChild(1).gameObject.GetComponent<Image>();
        img.sprite = onGetedImg?.Invoke(numLvl);
    }
}
