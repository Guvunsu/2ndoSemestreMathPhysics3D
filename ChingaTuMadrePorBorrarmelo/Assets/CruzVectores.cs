using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CruzVectores : MonoBehaviour
{
    public Vector3d VectorA;
    public Vector3d VectroB;
    public float c;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 u = VectorA.components;
        Vector3 v = VectroB.components;
        GetComponent<Vector3d>().components = new Vector3 (u.y * v.z - u.z * v.z, u.z * v.x - u.x * v.z - u.x * v.y - u.y * v.x);
    }
}
