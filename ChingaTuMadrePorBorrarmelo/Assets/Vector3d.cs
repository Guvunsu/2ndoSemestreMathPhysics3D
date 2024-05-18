using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class Vector3d : MonoBehaviour
{


    public Vector3 components;
    public Vector3 origin;
    public Color color;
    //public Material material;
    private Transform head;
    private Transform sphere;
    void Start()
    {
        sphere = transform.Find("Sphere");
        sphere.localScale = 0.3f * Vector3.one;
        head = transform.Find("Head");
        head.localScale = 0.25f * Vector3.one;
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
        GetComponent<LineRenderer>().positionCount = 2;

        //head.GetComponent<MeshRenderer>().material = material;
        //GetComponent<LineRenderer>().material = material;

    }

    void Update()
    {
        ModifyVector();
    }

    private void ModifyVector()
    {
        sphere.position = origin;
        head.position = origin + components;
        head.up = components;

        float magnitude = components.magnitude - 0.5f;
        GetComponent<LineRenderer>().SetPosition(0, origin);
        GetComponent<LineRenderer>().SetPosition(1, origin + magnitude * (components.normalized));

        sphere.GetComponent<MeshRenderer>().material.color = color;
        head.GetComponent<MeshRenderer>().material.color = color;
        GetComponent<LineRenderer>().material.color = color;



    }

    float Norm(Vector3 u)
    {
        return 0;
    }

    Vector3 Suma(Vector3 u, Vector3 v)
    {
        return Vector3.zero;
    }

    Vector3 Resta(Vector3 u, Vector3 v)
    {
        return Vector3.zero;
    }

    Vector3 ProductoxEscalar(float a, Vector3 u)
    {
        return Vector3.zero;
    }

    float ProductoPunto(Vector3 u, Vector3 v)
    {
        return 0;
    }

    Vector3 ProductoCruz(Vector3 u, Vector3 v)
    {
        return Vector3.zero;
    }

}