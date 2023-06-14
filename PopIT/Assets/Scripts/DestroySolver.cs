using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class DestroySolver : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKey (KeyCode.L))
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable() 
    {
        CameraUI.onNextLeveled += Delete;
    }
    private void OnDisable() 
    {
        CameraUI.onNextLeveled -= Delete;
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
}
