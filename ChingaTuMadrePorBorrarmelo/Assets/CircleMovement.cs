using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    float time;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float x = 20 * Mathf.Cos(time);
        float z = 20 * Mathf.Sin(time);
        transform.position = new Vector3(x, 0, z);
    }
}
