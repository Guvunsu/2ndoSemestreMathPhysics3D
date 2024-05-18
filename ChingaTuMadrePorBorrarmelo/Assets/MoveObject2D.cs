using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects2D : MonoBehaviour
{
    public Rectangle2D rectangle2D;
    public float speed;
    public float rootspeed;

    void Update()
    {
        float dt = Time.deltaTime;
        float HiInput = Input.GetAxis("Horizontal");
        float ViInput = Input.GetAxis("Vertical");
        transform.Rotate(transform.forward, rootspeed * HiInput * dt);
        transform.Translate(speed * ViInput * transform.up * dt, Space.World);

        Vector3 direction = new Vector3(0, ViInput, 0).normalized;
        Vector3 translation = speed * direction * dt;
        rectangle2D.TranslateObject(translation);


        float angle = HiInput * dt * 50;
        rectangle2D.RotateObject(angle);
    }


}
