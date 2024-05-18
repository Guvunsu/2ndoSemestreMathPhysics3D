using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    public Vector3 emissionVelocity;
    public float delayTime;
    private float time;
    private bool fired;


    private void FixedUpdate()
    {
        if (time >= delayTime && !fired)
        {
            fired = true;
            GetComponent<Rigidbody>().velocity = emissionVelocity;
        }
        time += Time.fixedDeltaTime;
    }
    void Start()
    {

    }


    void Update()
    {

    }
}
