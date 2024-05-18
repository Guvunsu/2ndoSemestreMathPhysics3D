using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK2Motion : MonoBehaviour
{
    public Vector2 pCurrent, vCurrent;
    public float m;

    private Vector2 pMiddle, vMiddle, pNext, vNext;
    void Start()
    {
        transform.position = pCurrent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        pMiddle = pCurrent + 0.5f * dt * vCurrent;
        vMiddle = vCurrent + 0.5f * dt * F(pCurrent, vCurrent) / m;

        pNext = pCurrent + dt * vMiddle;
        vNext = vCurrent + dt * F(pMiddle, vMiddle) / m;

        transform.position = pNext;
        pCurrent = pNext;
        vCurrent = vNext;
    }
    Vector2 F(Vector2 P, Vector2 V)
    {
        //return m * new Vector3(0, -9.81f, 0f);
        return -P / Mathf.Pow(P.magnitude, 3);
    }
}
