using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    public float swing;
    public Transform fireBalls;
    private BezierCurve1 _bezierCurve;
    private float time;

    void Start()
    {
        _bezierCurve = GetComponent<BezierCurve1>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controlPointsMovement();
        fireBallsMovement();
    }
    void fireBallsMovement()
    {
        for (int i = 0; i < fireBalls.childCount; i++)
        {
            float si = (float)i / (fireBalls.childCount - 1f);
            fireBalls.GetChild(i).position = _bezierCurve.Bezier(si);
        }
    }
    private void controlPointsMovement()
    {
        float z1 = _bezierCurve.P[1].position.z;
        float z2 = _bezierCurve.P[2].position.z;
        _bezierCurve.P[1].position = circlePath(5f, z1);
        _bezierCurve.P[2].position = circlePath(5f, z2);
        time += Time.fixedDeltaTime;
    }
    Vector3 circlePath(float radius, float zCoordinate)
    {
        float xCoordinate = radius * Mathf.Sin(swing * time);
        float yCoordinate = radius * Mathf.Cos(swing * time);
        return new Vector3(xCoordinate, yCoordinate, zCoordinate);
    }
}
