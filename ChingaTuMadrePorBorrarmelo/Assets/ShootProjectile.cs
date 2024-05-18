using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectileRB, projectileKinematic;
    public Vector3 velocity;


    void Start()
    {
        projectileRB.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileRB.GetComponent<Rigidbody>().isKinematic = false;
            projectileRB.GetComponent<Rigidbody>().position = Vector3.zero;
            projectileRB.GetComponent<Rigidbody>().velocity = velocity;

            projectileKinematic.GetComponent<ShootProjectileKinematic>().fired = true;
            projectileKinematic.GetComponent<ShootProjectileKinematic>().p0 = Vector3.zero;
            projectileKinematic.GetComponent<ShootProjectileKinematic>().v0 = velocity;

        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            projectileRB.GetComponent<Rigidbody>().isKinematic = true;
            projectileRB.transform.position = Vector3.zero;
            projectileRB.GetComponent<Rigidbody>().velocity = Vector3.zero;
            projectileRB.GetComponent<TrailRenderer>().Clear();

            projectileKinematic.GetComponent<ShootProjectileKinematic>().fired = false;
            projectileKinematic.transform.position = Vector3.zero;
            projectileKinematic.GetComponent<ShootProjectileKinematic>().v0 = Vector3.zero;
            projectileKinematic.GetComponent<ShootProjectileKinematic>().t = 0f;
            projectileKinematic.GetComponent<TrailRenderer>().Clear();

        }
    }
}
