using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerexample : MonoBehaviour
{
    public Transform A, B;

    [Range(0f, 1f)]
    public float s;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myLearp(A.position, B.position, s);
        transform.position = Vector3.Lerp(A.position, B.position, s);
    }
    Vector3 myLearp(Vector3 A, Vector3 B, float s)
    {
        return (B - A) * s + A;
    }
}
