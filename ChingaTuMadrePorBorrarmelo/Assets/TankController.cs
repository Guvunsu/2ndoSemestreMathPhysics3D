using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float tankspeed, tankRotSpeed;
    public float turretRotspeed;
    public Transform turret;
    private float Angley, AngleX;
    public Transform turretCanon, shootPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 position = shootPoint.position;
            Quaternion rotation = shootPoint.rotation;
            GameObject bullet = Instantiate(bulletPrefab ,position , rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * shootPoint.forward;
        }
        float dt = Time.deltaTime;
        float leftHorizontal = Input.GetAxis("L-stick-P1-Horizontal");
        float leftVertical = Input.GetAxis("L-stick-P1-Vertical");

        float tankAngle = tankRotSpeed * leftHorizontal * dt;
        transform.Rotate(transform.up, tankAngle, Space.Self);
        Vector3 translation = tankspeed * transform.forward * leftVertical * dt;
        transform.Translate(translation, Space.World);

        float Righthorizontal = Input.GetAxis("R-stick-P1-Horizontal");
      //  float LeftVertical = Input.GetAxis("R-stick-P1-Vertical");

        Angley -= turretRotspeed * Righthorizontal * dt;
        turret.localRotation = Quaternion.Euler(0f, Angley, 0f);

        //AngleX += turretRotspeed * Righthorizontal * dt;
        //AngleX = Mathf.Clamp(AngleX, -90f, 0);
        //turretCanon.localRotation = Quaternion.Euler(AngleX, 0f, 0f);

       
    }
}
