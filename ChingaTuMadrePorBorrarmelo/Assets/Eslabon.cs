using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eslabon : MonoBehaviour
{
    public float a, b;
    public float w, f;
    public float t = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            t += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            t -= Time.deltaTime;
        }

       // t += Time.deltaTime;
        
        transform.position = PositionFunction();
        transform.forward = Derivative();

    }
    Vector3 PositionFunction()
    {
        float x = 0;
        float y = b * Mathf.Cos(w * t + f);
        float z = a * Mathf.Sin(w * t + f);
        return new Vector3(x, y, z);

    }
    Vector3 Derivative()
    {
        float x = 0;
        float y = -w * b * Mathf.Sin(w * t + f);
        float z = w * a * Mathf.Cos(w * t + f);
        return new Vector3(x, y, z);
    }
}
