using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        rb.AddForce(Vector3.forward * dt * speed, ForceMode.Force);
    }
}
