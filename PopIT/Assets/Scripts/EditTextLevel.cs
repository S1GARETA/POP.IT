using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditTextLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLevel;
    void Start()
    {
        textLevel.text = $"LEVEL {PlayerPrefs.GetInt("numLvl")}";
    }
}
