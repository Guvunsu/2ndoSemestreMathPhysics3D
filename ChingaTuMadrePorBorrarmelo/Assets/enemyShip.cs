using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class enemyShip : MonoBehaviour
{
    public float r, h;
    public float w0, w1;
    public float f0, f1;

    public float t;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Path();
        transform.forward = Tangent();

       // Debug.Log("time");
    }

    Vector3 Path() //posicion
    {
        float x = r * Mathf.Cos(w0 * t + f0);
        float y = h * Mathf.Sin(w1 * t + f1);
        float z = r * Mathf.Sin(w0 * t + f0);

        return new Vector3(x, y, z);
    }
    Vector3 Tangent() //la orientacion 
    {
        float x = -w0 * r * Mathf.Cos(w0 * t + f0);
        float y = w1 * h * Mathf.Cos(w1 * t + f1);
        float z = w0 * r * Mathf.Cos(w0 * t + f0);

        return new Vector3(x, y, z);
    }
}
