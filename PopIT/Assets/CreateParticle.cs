using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Obi;

public class CreateParticle : MonoBehaviour
{
    public GameObject[] objSphere;
    public ObiSolver objSolver;
    public static Color objColor = Color.white;
    public void OnMouseDown() // По нажатию на сферу, она удаляется
    {
        objColor = gameObject.GetComponent<MeshRenderer>().sharedMaterial.color; // Забирает цвет сферы

        Destroy(gameObject);
        Instantiate(objSolver, gameObject.transform.position, Quaternion.identity);
    }
    public void Create() // Создаёт новые сферы по кнопке "создать"
    {
        foreach(var sp in objSphere)
        {
            Instantiate(sp, new Vector3(RandomNumber(), 1, RandomNumber()), Quaternion.Euler(0, 0, 0));
        }
        // objSphere[0].GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
        // Instantiate(objSphere[0], new Vector3(RandomNumber(), 6, RandomNumber()), Quaternion.Euler(0, 0, 0));
    }
    private float RandomNumber() // Просто рандом появления сфер
    {
        return Random.Range(-3, 3);
    }
}
