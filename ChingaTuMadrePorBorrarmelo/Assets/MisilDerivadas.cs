using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MisilDerivadas
{
    public float t;
    public float e;
    public Vector3 F1()
    {
        float x = 0;
        float y = 10 * e - Mathf.Pow(t, 0) * (3 * t);
        float z = 0;
        return new Vector3(x, y, z);
    }

    public Vector3 DF1()
    {
        float x = 0;
        float y = -e - Mathf.Pow(t, 0) * 10 * e * Mathf.Pow(t, 0) * (Mathf.Cos(3 * t)) * (-3 * Mathf.Sin(3 * t));
        float z = 0;
        return new Vector3(x, y, z);
    }

    public Vector3 F2()
    {
        float x = t * (Mathf.Cos(10 * t));
        float y = t * Mathf.Pow(t, 2);
        float z = t * Mathf.Sin(10 * t);
        return new Vector3(x, y, z);
    }
    public Vector3 DF2()
    {
        float x = -Mathf.Sin(10 * t);
        float y = 2 * t;
        float z = -10 * Mathf.Sin(10 * t) * (10 * Mathf.Cos(10 * t) * (10 * Mathf.Sin(10 * t)) * (-10 * Mathf.Cos(10 * t)));
        return new Vector3(x, y, z);
    }

    public Vector3 F3()
    {
        float x = e * Mathf.Pow(1 / 10, t) * Mathf.Sin(5 * t);
        float y = 2 * t;
        float z = e * Mathf.Pow(1 / 10, t) * Mathf.Cos(5 * t);
        return new Vector3(x, y, z);
    }
    public Vector3 DF3()
    {
        float x = -5 * e * Mathf.Pow(1 / 2, t) * (e * Mathf.Pow(1 / 2, t)) * Mathf.Sin(5 * t);
        float y = 2 * t;
        float z = -5 * e * Mathf.Pow(1 / 2, t) * (-5 * Mathf.Sin(5 * t)) * (e * Mathf.Pow(1 / 2, t)) * Mathf.Cos(5 * t);
        return new Vector3(x, y, z);
    }

    public Vector3 F4()
    {
        float x = 20 * Mathf.Cos(2 * t) * (Mathf.Cos(5 * t + 2));
        float y = 20 * Mathf.Sin(2 * t) * (Mathf.Cos(5 * t + 2));
        float z = -20 * Mathf.Sin(5 * t);
        return new Vector3(x, y, z);
    }

    public Vector3 DF4()
    {
        float x = -40 * Mathf.Sin(2 * t) * (Mathf.Cos(5 * t + 2)) * (20 * Mathf.Cos(2 * t)) * (-5 * Mathf.Sin(5 * t));
        float y = -40 * Mathf.Cos(2 * t) * (Mathf.Cos(5 * t) - (5 * Mathf.Sin(5 * t) * (Mathf.Cos(5 * t))));
        float z = -100 * Mathf.Cos(5 * t);
        return new Vector3(x, y, z);
    }
}
