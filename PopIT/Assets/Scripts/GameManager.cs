using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable() 
    {
        Cube.onTouched += ConsoleMessage;
    }
    private void OnDisable() 
    {
        Cube.onTouched -= ConsoleMessage;
    }
    private string ConsoleMessage(int value)
    {
        return $"Кубик ударился о землю! {value}";
    }
}
