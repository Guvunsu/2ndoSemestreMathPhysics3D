using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointSolid : MonoBehaviour
{
    [Header("Longitud del sólido")]
    public float length;
    [Header("Anchura del sólido")]
    public float width;
    [Header("Altura del sólido")]
    public float height;

    public static Vector3[] vertices = new Vector3[8];
    void Start()
    {
        InitVertices();
        InitLineRenderers();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitVertices();
        }
    }

    void LateUpdate()
    {
        UpdateLineRenderers();
    }

    // No mires el código, tengo todo regado :u

    void UpdateLineRenderers()
    {
        Vector3[] v0 = { vertices[0], vertices[1], vertices[5], vertices[6] };
        Vector3[] v1 = { vertices[1], vertices[2], vertices[6], vertices[7] };
        Vector3[] v2 = { vertices[2], vertices[3], vertices[7], vertices[4] };
        Vector3[] v3 = { vertices[3], vertices[0], vertices[4], vertices[5] };


        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<LineRenderer>().positionCount = 4;
        }

        transform.GetChild(0).GetComponent<LineRenderer>().SetPositions(v0);
        transform.GetChild(1).GetComponent<LineRenderer>().SetPositions(v1);
        transform.GetChild(2).GetComponent<LineRenderer>().SetPositions(v2);
        transform.GetChild(3).GetComponent<LineRenderer>().SetPositions(v3);
    }

    void InitVertices()
    {
        float a = length;
        float b = height;
        float c = width;

        vertices[0] = 0.5f * new Vector3(c, -b, -a);
        vertices[1] = 0.5f * new Vector3(c, -b, a);
        vertices[2] = 0.5f * new Vector3(-c, -b, a);
        vertices[3] = 0.5f * new Vector3(-c, -b, -a);
        vertices[4] = 0.5f * new Vector3(c, b, -a);
        vertices[5] = 0.5f * new Vector3(c, b, a);
        vertices[6] = 0.5f * new Vector3(-c, b, a);
        vertices[7] = 0.5f * new Vector3(-c, b, -a);
    }

    void InitLineRenderers()
    {
        foreach (Transform t in transform)
        {
            t.AddComponent<LineRenderer>();
        }

        foreach (Transform t in transform)
        {
            t.GetComponent<LineRenderer>().widthMultiplier = 0.05f;
            t.GetComponent<LineRenderer>().numCapVertices = 5;
            t.GetComponent<LineRenderer>().numCornerVertices = 5;
        }
    }
}
