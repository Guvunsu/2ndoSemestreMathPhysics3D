using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion2D
{
    public static float SingleWave(float A, Vector2 k, float w, float phi, float t, float x, float z)
    {
        float result = A * Mathf.Sin(k.x + x + k.y * z - w * t - phi);
        return result;
    }
    public static float SumWave(List<float> A, List<Vector2> k, List<float> W, List<float> PHI, float T, float X, float Z)
    {
        float sum = 0;
        for (int i = 0; i < A.Count; i++)
        {
            sum += SingleWave(A[i], k[i], W[i], PHI[i], T, X, Z);
        }
        return sum;
    }
}

