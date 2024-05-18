using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileKinematic : MonoBehaviour
{
    public Vector3 p0, v0;
    [System.NonSerialized] public float t;
    public bool fired = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fired)
        {
            transform.position = P(t);
            t += Time.deltaTime;
        }

    }
    Vector3 P(float t)
    {
        Vector3 gravity = Physics.gravity;
        return 0.5f * gravity * t * t + v0 * t + p0;
    }
}
