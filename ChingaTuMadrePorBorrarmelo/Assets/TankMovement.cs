using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed, rotSpeed;

    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = shootPoint.position;
            Quaternion rotation = shootPoint.rotation;
            GameObject bullet = Instantiate(bulletPrefab, position, rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * shootPoint.forward;
            Destroy(bullet, 10f);
        }
    }

    // Update is called once per frame
    void Movement()
    {
        float HiInput = Input.GetAxis("Vertical");
        float ViInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, rotSpeed * HiInput * Time.deltaTime);
        transform.Translate(speed * transform.forward * Time.deltaTime, Space.World);

    }
}
