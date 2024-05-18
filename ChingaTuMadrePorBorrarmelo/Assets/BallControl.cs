using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb;
    public float torqueMagnitud;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float HiInput = Input.GetAxis("Horizontal");
        float ViInput = Input.GetAxis("Vertical");
        Vector3 DiInput = new Vector3(HiInput, 0, ViInput).normalized;
        Vector3 torque = Vector3.Cross(Vector3.up, DiInput);
        rb.AddTorque(torqueMagnitud * torque, ForceMode.Force);
    }
}
