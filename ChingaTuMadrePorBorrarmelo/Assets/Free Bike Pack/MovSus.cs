using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSus : MonoBehaviour
{

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravity;
    private bool isGround;

    Vector3 direction;
    Vector3 torqueDirection;
    public Rigidbody rbJumper;
    public KeyCode key;
    void Start()
    {
        getComponents();
    }

    // Update is called once per frame
    void Update()
    {
        movUp();
    }

    void getComponents()
    {
        rbJumper.GetComponent<Rigidbody>();
    }
    void movUp()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        if (isGround && Input.GetKeyDown(key))
        {
            rbJumper.AddForce(jumpForce * transform.up, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpikedWheel"))
        {
            rbJumper.constraints = RigidbodyConstraints.None;
            direction = new Vector3(1, 1, 0).normalized;
            rbJumper.AddForce(10f * direction, ForceMode.Impulse);
            torqueDirection = Random.onUnitSphere;
            rbJumper.AddTorque(100f * torqueDirection, ForceMode.Impulse);
        }
    }
}
