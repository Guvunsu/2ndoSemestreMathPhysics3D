using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoPlayer : MonoBehaviour
{
    public float speed, dt, heightImpulse, forceImpulse;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("HorizontalWASD");
        float vInput = Input.GetAxis("VerticalWASD");
        Vector3 direction = new Vector3(hInput, 0, vInput).normalized;
        rb.AddForce(forceImpulse * direction * dt, ForceMode.Force);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("CylinderArea"))
        {
            //GetComponent<Rigidbody>().AddForce(heightImpulse * transform.up, ForceMode.Impulse);
            Vector3 force = heightImpulse * transform.up;
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
