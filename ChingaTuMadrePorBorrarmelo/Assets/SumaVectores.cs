using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumaVectores : MonoBehaviour
{
    public Vector3d VectorA;
    public Vector3d VectorB;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Vector3d>().components = VectorA.components + VectorB.components;



    }
}
