using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretPlayer : MonoBehaviour
{
    public Transform y_Axis;
    public Transform x_Axis;
    public float rotSpeed;
    private float angleX, angleY;

    public float bulletSpeed, bulletLifeSpan;
    public Transform shootPoint;
    public GameObject bulletPrefab;


    void Update()
    {
        HorizontalRotation();
        VerticalRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }

    void HorizontalRotation()
    {
        float dt = Time.fixedDeltaTime;
        float hInput = Input.GetAxis("Horizontal");
        float angle = rotSpeed * hInput * dt;
        angleX -= rotSpeed * hInput * dt;
        angleX = Mathf.Clamp(angleX, -45f, 0f);
        //Vector3 eulerAngles = new Vector3(0, angle, 0);
        // y_Axis.Rotate(eulerAngles, Space.Self);
        y_Axis.localRotation = Quaternion.Euler(0, angleY, 0);
    }

    void VerticalRotation()
    {
        float dt = Time.fixedDeltaTime;
        float vInput = Input.GetAxis("Vertical");
        angleX -= rotSpeed * vInput * dt;
        angleX = Mathf.Clamp(angleX, -45f, 0f);
        x_Axis.localRotation = Quaternion.Euler(angleX, 0, 0);
    }

    void Fire()
    {
        Vector3 position = shootPoint.position;
        Quaternion rotation = shootPoint.rotation;
        GameObject bullet = Instantiate(bulletPrefab, position, rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * shootPoint.forward;
        Destroy(bullet, bulletLifeSpan);
    }
}
