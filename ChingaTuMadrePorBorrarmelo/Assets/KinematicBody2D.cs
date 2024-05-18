using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBody2D : MonoBehaviour
{
    public float speed;
    bool isFired = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isFired && Input.GetKeyDown(KeyCode.Space))
        {
            isFired = true;
            //GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
            // GetComponent<Rigidbody2D>().AddForce(,);
        }
    }
}
