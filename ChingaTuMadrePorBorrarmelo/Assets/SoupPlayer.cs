using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float forceMagnitud, torqueMagnitud;
    public string horizontalInputName, verticalInputName;
    public LayerMask bowlLayer;
    public AudioClip clip;
    public AudioSource audiosource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementControl2();
        RotationRectification();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void MovementControl2()
    {
        float dt = Time.deltaTime;
        float HiInput = Input.GetAxis(horizontalInputName);
        float ViInput = Input.GetAxis(verticalInputName);

        Vector3 Inputdir = new Vector3(HiInput, 0, ViInput).normalized;
        Vector3 newDir = Inputdir - Vector3.Dot(Inputdir, transform.up) * transform.up;
        Vector3 force = forceMagnitud * newDir * dt;


        //Vector3 torque = torqueMagnitud * transform.up * HiInput * dt;
        //Vector3 force = forceMagnitud * transform.forward * dt;
        //rb.AddTorque(torque, ForceMode.Force);
        rb.AddForce(force, ForceMode.Force);

    }
    void MovementControlP1()
    {
        float dt = Time.deltaTime;
        float HiInput = Input.GetAxis(horizontalInputName);
        float ViInput = Input.GetAxis(verticalInputName);

        Vector3 Inputdir = new Vector3(HiInput, 0, ViInput).normalized;
        Vector3 newDir = Inputdir - Vector3.Dot(Inputdir, transform.up) * transform.up;
        Vector3 force = forceMagnitud * newDir * dt;


        //Vector3 torque = torqueMagnitud * transform.up * HiInput * dt;
        //Vector3 force = forceMagnitud * transform.forward * dt;
        //rb.AddTorque(torque, ForceMode.Force);
        rb.AddForce(force, ForceMode.Force);

    }
    void RotationRectification()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10, bowlLayer))
        {
            Vector3 newUp = hit.normal;
            Vector3 newForward = transform.forward - Vector3.Dot(transform.forward, newUp) * newUp;
            transform.rotation = Quaternion.LookRotation(newForward, newUp);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BowlLimit"))
        {
            float forceMagnitud = 10;
            float torqueMagnitud = 10;
            Vector3 force = forceMagnitud * (transform.position.normalized);
            Vector3 torque = torqueMagnitud * Random.onUnitSphere;
            rb.AddForce(force, ForceMode.Impulse);
            rb.AddTorque(torque, ForceMode.Impulse);
            audiosource.PlayOneShot(clip);
        }
    }

}
