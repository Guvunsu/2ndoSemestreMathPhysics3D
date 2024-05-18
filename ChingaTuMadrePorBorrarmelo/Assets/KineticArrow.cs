using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticArrow : MonoBehaviour
{

    [System.NonSerialized] public Vector3 P0, V0;
    [System.NonSerialized] public bool fired;
    [System.NonSerialized] public Transform shootPoint;
    float time;
    void Start()
    {
        this.gameObject.AddComponent<TrailRenderer>();
        fired = false;
        GetComponent<TrailRenderer>().widthMultiplier = 0.05f;
        GetComponent<TrailRenderer>().time = 0.15f;
        GetComponent<TrailRenderer>().Clear();
        GetComponent<TrailRenderer>().emitting = false;
    }

    void Update()
    {
        if (fired)
        {
            time += Time.deltaTime;
            transform.position = ArrowPosition();
            transform.forward = ArrowVelocity();
        }
        else
        {
            transform.position = shootPoint.position;
            transform.rotation = shootPoint.rotation;
        }
    }

    Vector3 ArrowPosition()
    {
        Vector3 gravity = new Vector3(0, -9.81f, 0);
        return 0.5f * gravity * time * time + V0 * time + P0;
    }

    Vector3 ArrowVelocity()
    {
        Vector3 gravity = new Vector3(0, -9.81f, 0);
        return gravity * time + V0;
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }
    //public Vector3 p0, v0;
    //public bool fired;
    //public Transform shootPoint;
    //float time;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    fired = false;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (fired)
    //    {
    //        time += Time.deltaTime;
    //        transform.position = ArrowPosition(time, p0, v0);
    //        transform.forward = ArrowVelocity(time, p0, v0);
    //    }
    //    else
    //    {
    //        transform.position = shootPoint.position;
    //        transform.rotation = shootPoint.rotation;
    //    }
    //}
    //Vector3 ArrowPosition(float time, Vector3 initialPosition, Vector3 initialVelocity)
    //{
    //    Vector3 gravity = new Vector3(0, -9.81f, 0);
    //    return 0.5f * gravity * time * time + initialVelocity * time + initialPosition;
    //}
    //Vector3 ArrowVelocity(float time, Vector3 initialPosition, Vector3 initialVelocity)
    //{

    //    Vector3 gravity = new Vector3(0, -9.81f, 0);
    //    return gravity * time + initialVelocity;
    //}
}
