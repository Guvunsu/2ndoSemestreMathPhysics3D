using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    public float angularSpeed;
    private float xAngle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Horizontal");
        xAngle += angularSpeed * vInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(xAngle, 0, 0);

    }
}
