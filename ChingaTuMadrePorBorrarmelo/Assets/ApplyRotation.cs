using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ApplyRotation : MonoBehaviour
{
    public float yAngle;
    public float xAngle;
    public float zAngle;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            RotationVertices(Ry(yAngle));
        }
        if (Input.GetKey(KeyCode.X))
        {
            RotationVertices(Rx(xAngle));
        }
        if (Input.GetKey(KeyCode.Z))
        {
            RotationVertices(Rz(zAngle));
        }
    }

    float[,] Rx(float theta)
    {
        float CosQ = Mathf.Cos(theta * Mathf.Deg2Rad);
        float SinQ = Mathf.Sin(theta * Mathf.Deg2Rad);
        float[,] Matrix = {
        { 1 , 0 , 0},
        { 0, CosQ ,-SinQ},
        {0 , SinQ, CosQ }
        };
        return Matrix;

    }
    float[,] Ry(float Theta)
    {
        float CosQ = Mathf.Cos(Theta * Mathf.Deg2Rad);
        float SinQ = Mathf.Sin(Theta * Mathf.Deg2Rad);
        float[,] Matrix = {
        { CosQ , 0 , SinQ},
        { 0,1,0},
        {-SinQ , 0, CosQ }
        };
        return Matrix;



    }

    float[,] Rz(float Thetas)
    {
        float CosQ = Mathf.Cos(Thetas * Mathf.Deg2Rad);
        float SinQ = Mathf.Sin(Thetas * Mathf.Deg2Rad);
        float[,] Matrix = {
        { CosQ , -SinQ, 0},
        { SinQ,CosQ,0},
        {0 , 0, 1 }
        };
        return Matrix;
    }

    Vector3 MatrixVectorProduct(float[,] M, Vector3 u)
    {
        float vx = M[0, 0] * u.x + M[0, 1] * u.y + M[0, 2] * u.z;
        float vy = M[1, 0] * u.x + M[1, 1] * u.y + M[1, 2] * u.z;
        float vz = M[2, 0] * u.x + M[2, 1] * u.y + M[2, 2] * u.z;

        float Rx = M[0, 0] * u.x + M[0, 1] * u.y + M[0, 2] * u.z;
        float Ry = M[1, 0] * u.x + M[1, 1] * u.y + M[1, 2] * u.z;
        float Rz = M[2, 0] * u.x + M[2, 1] * u.y + M[2, 2] * u.z;


        return new Vector3(vx, vy, vz);
    }

    void RotationVertices(float[,] M)
    {
        for (int i = 0; i < PointSolid.vertices.Length; i++)
        {
            Vector3 vi = PointSolid.vertices[i];
            Vector3 viRotated = MatrixVectorProduct(M, vi);
            PointSolid.vertices[i] = viRotated;
        }
    }

}
