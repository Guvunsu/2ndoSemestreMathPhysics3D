using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileNumeric : MonoBehaviour
{
    public Vector3 pI, vI;
    private Vector3 pF, vF, g;
    float dt;
    void Start()
    {
        g = new Vector3(0, -9.81f, 0);
        pI = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        pF = pI + dt * vI;
        vF = vI + dt * g;
        transform.position = pF;
        pI = pF;
        vI = vF;
    }
}
