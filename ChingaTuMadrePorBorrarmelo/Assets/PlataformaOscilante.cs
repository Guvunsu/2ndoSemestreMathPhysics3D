using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaOscilante : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float travelTime;
    public float t;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = PositionFunction(t);
    }

    Vector3 PositionFunction(float t)
    {
        Vector3 a = pointA.position;
        Vector3 b = pointB.position;
        float w = Mathf.PI / travelTime;
        return (b - a) * (Mathf.Sin(w * t)+1)/2 + a;
    }
}
