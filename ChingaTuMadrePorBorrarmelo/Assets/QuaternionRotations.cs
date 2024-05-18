using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class QuaternionRotations : MonoBehaviour
{
    public Vector3 axis;
    public float angle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Vector3.zero, axis, Color.blue);
        Quaternion q = AxisAngle(axis, angle);
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < PointSolid.vertices.Length; i++)
            {
                Vector3 vi = PointSolid.vertices[i];
                PointSolid.vertices[i] = RotatedVector(q, vi);

            }
        }
    }

    Vector3 RotatedVector(Quaternion q, Vector3 p)
    {
        Quaternion pQuaternion = new Quaternion(p.x, p.y, p.z, 0);
        Quaternion qInv = Quaternion.Inverse(q);
        Quaternion pRotated = qInv * pQuaternion * q;
        Vector3 result = new Vector3(pRotated.x, pRotated.y, pRotated.z);
        return result;
    }


    Quaternion AxisAngle(Vector3 axis, float angle)
    {
        axis.Normalize();
        float x = axis.x;
        float y = axis.y;
        float z = axis.z;
        float Q = angle * Mathf.Deg2Rad;
        float CosQ2 = Mathf.Cos(Q / 2);
        float SinQ2 = Mathf.Sin(Q / 2);
        return new Quaternion(x * SinQ2, y * SinQ2, z * SinQ2, CosQ2);
    }
}
