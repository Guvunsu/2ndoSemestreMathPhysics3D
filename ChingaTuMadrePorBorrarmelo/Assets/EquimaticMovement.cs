using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquimaticMovement : MonoBehaviour
{
    public float time;
    public Vector3 velocity;
    public Vector3 initialPosition;
    public Vector3 gravity;

    void Update()
    {
        time += Time.deltaTime;
        // transform.position = PositionFunction(time);
        // transform.position = MRU(time, initialPosition, velocity);
        transform.position = ParabolicShoot(time, initialPosition, velocity, gravity);
    }

    Vector3 PositionFunction(float t)
    {
        //float x = 10 * Mathf.Cos(10 * t);
        //float y = 10 * Mathf.Sin(10 * t);
        //float z = 2 * t - 5;
        //return new Vector3(x, y, z);


        int n = 4;

        float cos = Mathf.Cos(t);
        float sin = Mathf.Sin(t);
        float absCos = Mathf.Abs(cos);
        float absSin = Mathf.Abs(sin);
        float sgnCos = Mathf.Sign(cos);
        float sgnsin = Mathf.Sign(sin);

        float x = 10 * Mathf.Pow(absCos, 2f / n) * sgnCos;
        float y = 10 * Mathf.Pow(absSin, 2f / n) * sgnsin;
        return new Vector3(x, y, 0);

        //si lo quiero que se mueva acostado , cambio la y por z y al final ponerle (x,0,z)

    }
    Vector3 MRU(float T, Vector3 P0, Vector3 V)
    {
        return V * T + P0;
    }
    Vector3 ParabolicShoot(float t, Vector3 p0, Vector3 v0, Vector3 g)
    {
        return g / 2 * Mathf.Pow(t, 2) + v0 * t + p0;
    }
}
