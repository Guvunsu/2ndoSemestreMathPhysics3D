using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedCylinder : MonoBehaviour
{
    public float rotSpeed, torqueMagnitud;

    float dt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        float hInput = Input.GetAxis("HorizontalArrows");
        transform.Rotate(0f, rotSpeed * dt * hInput, 0f, Space.Self);

        //Vector3 torque = torqueMagnitud * transform.up * hInput;
        //GetComponent<Rigidbody>().AddTorque(torque * dt, ForceMode.Force);//ponerle el Impulse


        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.Rotate(0, rotSpeed * dt, Vector3.left.z);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.Rotate(0, -rotSpeed * dt, Vector3.left.z);
        //}
    }
    //void Movement()
    //{
    //    dt = Time.deltaTime;
    //    float hInput = Input.GetAxis("Horizontal");
    //    transform.Rotate(0f, rotSpeed * dt * hInput, 0f, Space.Self);
    //}
}
