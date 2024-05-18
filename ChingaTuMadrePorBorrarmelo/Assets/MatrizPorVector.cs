using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrizPorVector : MonoBehaviour
{

    void Start()
    {
        float[,] M = new float[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        Vector3 V = new Vector3(1, 1, 1);

        Debug.Log(Producto(M, V));

        Debug.Log("");
    }


    void Update()
    {

    }

    Vector3 Producto(float[,] M, Vector3 V)
    {
        float UX = M[0, 0] * V.x + M[0, 1] * V.y + M[0, 2] * V.z;

        float UY = M[1, 0] * V.x + M[1, 1] * V.y + M[1, 2] * V.z;

        float UZ = M[2, 0] * V.x + M[2, 1] * V.y + M[2, 2] * V.z;

        return new Vector3(UX, UY, UZ);
    }
}
