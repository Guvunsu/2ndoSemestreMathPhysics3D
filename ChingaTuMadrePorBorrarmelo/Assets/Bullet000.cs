using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet000 : MonoBehaviour
{
    public Vector3 p0, v0;

    float t;
    private void Update()
    {
        t += Time.deltaTime;
        transform.position = Path();
      //  transform.forward = Tangent();


    }
    Vector3 Path()
    {
        Vector3 g = new Vector3(0f, -9.81f, 0f);
        return 0.5f * g * t * t + v0 * t + p0;

    }
    Vector3 Tangent()
    {
        Vector3 g = new Vector3(0f, -9.81f, 0f);
        return g * t + v0;
    }
}
