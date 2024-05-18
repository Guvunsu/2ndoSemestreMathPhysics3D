using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTorreta : MonoBehaviour
{
    public float roSpeed;
    private float AngleX;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed;

    public Transform AxisX;
    public Transform AxisY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalRotation();
        VerticalRotation();

        if ( Input.GetMouseButton(0))
        {
            GameObject go = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            //necesita una referencia el GameObject para que lo aparezca 
            go.GetComponent<Bullet000>().p0 = shootPoint.position;
            go.GetComponent<Bullet000>().v0 = bulletSpeed * shootPoint.forward;
            Destroy(go, 30f);
        }
    }

    void HorizontalRotation()
    {
        float dt = Time.deltaTime;
        float HiInput = Input.GetAxis("Horizontal");
        float angle = roSpeed * dt * HiInput;
        Vector3 eulerAngles = new Vector3(0, angle, 0);
        AxisY.Rotate(eulerAngles, Space.Self);
    }

    void VerticalRotation()
    {
        float dt = Time.deltaTime;
        float ViInput = Input.GetAxis("Vertical");
        AngleX -= roSpeed * dt * ViInput;
        AngleX = Mathf.Clamp(AngleX, -90f, 0f);
        AxisX.localRotation = Quaternion.Euler(AngleX, 0, 0);
    }
}
