using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Obi;

public class CreateParticle : MonoBehaviour
{
    public ObiSolver objSolver;
    public static Color objColor = Color.white;
    public static Vector3 direction;
    
    public void OnMouseDown() // По нажатию на сферу, она удаляется
    {
        CameraUI.countSphere--;
        objColor = gameObject.GetComponent<MeshRenderer>().sharedMaterial.color; // Забирает цвет сферы
        direction = gameObject.transform.eulerAngles;

        Destroy(gameObject);
        Instantiate(objSolver, gameObject.transform.position, Quaternion.identity);
    }

}
