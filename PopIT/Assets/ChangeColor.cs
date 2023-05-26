using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class ChangeColor : MonoBehaviour
{
    // Скрипт, который меняет цвет частиц в зависимости от цвета сферы
    private Color myColor;
    private ObiEmitter objEmit;
    public void Start()
    {
        myColor = CreateParticle.objColor;
        var objEmit = GetComponent<ObiEmitter>();
        // objEmit.GetComponent<ObiParticleRenderer>().particleColor = new Color(Random.value, Random.value, Random.value, 1);
        objEmit.transform.eulerAngles = new Vector3(CreateParticle.direction.x, CreateParticle.direction.y, 0);
        objEmit.GetComponent<ObiParticleRenderer>().particleColor = myColor;
    }

    private float RandomNumber() // Просто рандом
    {
        return Random.Range(0, 360);
    }
}
