using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySolver : MonoBehaviour
{
    // Удаление партиклов на L
    void Update()
    {
        if(Input.GetKey (KeyCode.L))
        {
            Destroy(gameObject);
        }
    }
}
