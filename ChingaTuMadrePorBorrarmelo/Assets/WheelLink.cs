using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelLink : MonoBehaviour
{
    public float width, height, phi;
    public float t;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = Elipse();
        // transform.forward = ElipseDerivation();
        Vector3 forward = ElipseDerivative();
        Vector3 upward = Vector3.Cross(forward, Vector3.right);
        Quaternion linkRotation = Quaternion.LookRotation(forward, upward);
        transform.localRotation = linkRotation;

    }
    Vector3 Elipse()
    {
        float x = 0;
        float y = -height * Mathf.Sin(t - phi);
        float z = width * Mathf.Cos(t - phi);
        return new Vector3(x, y, z);
    }

    Vector3 ElipseDerivative()
    {
        float x = 0;
        float y = -height * Mathf.Cos(t - phi);
        float z = -width * Mathf.Sin(t - phi);
        return new Vector3(x, y, z);
    }
}
