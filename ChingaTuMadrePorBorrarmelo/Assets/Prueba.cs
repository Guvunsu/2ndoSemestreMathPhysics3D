using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VectorOperations vectorOperatons = new VectorOperations();
        Vector3 vecA = new Vector3(10, 5, 3);
        Vector3 vecB = new Vector3(3, 2, 1);
        Vector3 resultSuma = vectorOperatons.Suma(vecA, vecB);

        float product1 = Vector3.Dot(vecB, vecA);
        Vector3 product = Vector3.Cross(vecA, vecB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
