using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorPunto : MonoBehaviour
{
    public Vector3d VectorA;
    public Vector3d VectorB;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 A = VectorA.components;
        Vector3 B = VectorB.components;

        float dotProduct = A.x + B.x + A.y * B.y + A.z * B.z;
        GetComponent<TextMesh>().text = dotProduct.ToString();
    }
}
