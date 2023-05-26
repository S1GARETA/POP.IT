using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public static Func<int, string> onTouched;
    // string test = "Ай! ";
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log(onTouched?.Invoke(2));
    }
}
