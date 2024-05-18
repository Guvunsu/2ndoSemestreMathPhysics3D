using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalasPong : MonoBehaviour
{

    public float paddlespeed;
    public Rigidbody2D rb;
    public float velocity;
    public Vector2 initialVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HiInput = Input.GetAxis("Horizontal");

        Vector2 velocity = paddlespeed * new Vector2(0, HiInput);

        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
