using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftControl : MonoBehaviour
{
    public float impulse;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float HiInput = Input.GetAxis("Horizontal");
        float ViInput = Input.GetAxis("Vertical");
        Vector3 DiInput = new Vector3(HiInput, 0, ViInput).normalized;
        GetComponent<Rigidbody>().AddForce(impulse * DiInput, ForceMode.Force);
    }
}
