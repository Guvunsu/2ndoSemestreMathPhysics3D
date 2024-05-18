using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class VectorOperations
{
    public VectorOperations()
    {

    }
    public float Norm(Vector3 u)
    {
        return Mathf.Sqrt(Mathf.Pow(u.x, 2) + Mathf.Pow(u.y, 2) + Mathf.Pow(u.z, 2));
    }
    public Vector3 Suma(Vector3 u, Vector3 v)
    {
        return new Vector3(u.x + v.x, u.y + v.y, u.z + v.z);
    }
    public Vector3 Resta(Vector3 u, Vector3 v)
    {
        return new Vector3(u.x - v.x, u.y - v.y, u.z - v.z);
    }
    public Vector3 ProductoxEscalar(float a, Vector3 u)
    {
        return new Vector3(a * u.x, a * u.y, a * u.z);
    }
    public float ProductoPunto(Vector3 u, Vector3 v)
    {
        return (u.x * v.x + u.x * v.y + u.x * v.z);
    }
    public Vector3 productoCruz(Vector3 u, Vector3 v)
    {
        return new Vector3(u.y * v.z - u.z * v.z, u.z * v.x - u.x * v.z - u.x * v.y - u.y * v.x);
    }
}
