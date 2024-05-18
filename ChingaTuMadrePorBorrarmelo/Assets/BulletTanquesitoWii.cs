using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTanquesitoWii : MonoBehaviour
{
    private int collisionCount;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Barrier"))
        {
            Vector3 forward = GetComponent<Rigidbody>().velocity.normalized;
            Quaternion rotation = Quaternion.LookRotation(forward, Vector3.up);
            transform.rotation = rotation;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Barrier"))
        {
            collisionCount++;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
