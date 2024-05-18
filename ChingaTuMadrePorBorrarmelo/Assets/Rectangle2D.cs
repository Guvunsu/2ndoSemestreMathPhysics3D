using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle2D : MonoBehaviour
{
    public Vector3[] vertices = new Vector3[4];
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.loop = true;
        lineRenderer.widthMultiplier = 0.1f;
    }

    void Update()
    {
        SetVertices();
    }

    public void SetVertices()
    {
        int verticesCount = vertices.Length;
        lineRenderer.positionCount = verticesCount;
        lineRenderer.SetPositions(vertices);
    }

    public void TranslateObject(Vector3 translation)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            //vertices[i] = vertices[i] + translation;
            vertices[i] += translation;
        }
    }

    public void RotateObject(float angle)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            //vertices[i] = vertices[i] + translation;
            vertices[i] = RotatedVector(vertices[i], angle);
        }
    }

    Vector3 RotatedVector(Vector3 V, float Angle)
    {
        float cos = Mathf.Cos(Angle);
        float sin = Mathf.Sin(Angle);

        float x = cos * (V.x) - sin * (V.y);


        float y = sin * (V.x) + cos * (V.y);

        return new Vector3(x, y, 0);

    }

    public void CreateVertices(Vector3 center, Vector2 size)
    {
        float width = size.x;
        float height = size.y;

        Vector3 p0 = center + new Vector3(width / 2f, height / 2f, 0);
        Vector3 p1 = center + new Vector3(-width / 2f, height / 2f, 0);
        Vector3 p2 = center + new Vector3(-width / 2f, -height / 2f, 0);
        Vector3 p3 = center + new Vector3(width / 2f, -height / 2f, 0);

        vertices = new Vector3[] { p0, p1, p2, p3 };
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);
    }

    public void SetColor(Color color)
    {
        lineRenderer.material.color = color;
    }
}