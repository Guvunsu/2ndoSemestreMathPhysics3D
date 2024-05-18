using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    public float speed, rootspeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float ViInput = Input.GetAxis("HorizontalWASD");
        float HiInput = Input.GetAxis("VerticalWASD");
        transform.Rotate(transform.up, rootspeed * HiInput * dt);
        transform.Translate(speed * ViInput * transform.forward * dt, Space.World);

    }
}
