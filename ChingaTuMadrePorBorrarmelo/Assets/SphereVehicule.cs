using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SphereVehicule : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public Transform SpherePlanet;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SurfaceMOvement();
    }
    void SurfaceMOvement()
    {
        float dt = Time.deltaTime;
        float HiInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, rotSpeed * HiInput * dt, Space.World);

        Vector3 translatePosition = transform.position + speed * transform.forward * dt;
        Vector3 translatedUp = NormalToSurface(translatePosition);
        float dotProduct = Vector3.Dot(transform.forward, translatedUp);
        Vector3 translatedForward = (transform.forward - dotProduct * translatedUp).normalized;
        Quaternion newRotation = Quaternion.LookRotation(translatedForward, translatedUp);
        transform.rotation = newRotation;

        float radius = SpherePlanet.localScale.x / 2f;
        Vector3 newPosition = (radius + 5) * NormalToSurface(translatePosition);
        transform.position = newPosition;

    }
    Vector3 NormalToSurface(Vector3 Position)
    {
        float x = Position.x;
        float y = Position.y;
        float z = Position.z;

        return new Vector3(x, y, z).normalized;
    }
}
