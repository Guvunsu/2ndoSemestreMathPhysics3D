using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanController : MonoBehaviour
{

    public Transform target;
    public static float hitTime;
    public KeyCode key;
    private Animator animator;


    void Start()
    {
        hitTime = 5f;
        animator = GetComponent<Animator>();
        GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            animator.SetTrigger("Move");
        }
    }

    public void EnableCollider()
    {
        bool isEnable = GetComponent<BoxCollider>().enabled;
        GetComponent<BoxCollider>().enabled = !isEnable;
    }

    private Vector3 hitVelocity(Vector3 P0)
    {
        Vector3 pf = target.position;
        Vector3 g = Physics.gravity;
        return (pf - P0) / hitTime - 0.5f * g * hitTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            hitTime -= 0.5f;
            hitTime = Mathf.Clamp(hitTime, 0.1f, Mathf.Infinity);
            Vector3 p0 = other.transform.position;
            Vector3 hitsvelocity = hitVelocity(p0);
            Vector3 randomTorque = 100f * Random.onUnitSphere;
            other.GetComponent<Rigidbody>().velocity = hitsvelocity;
            other.GetComponent<Rigidbody>().AddTorque(randomTorque, ForceMode.Impulse);
        }
    }

    //    public Transform leftPlayer, rightPlayer;
    //    public float hitTime;
    //    private Animator animator;
    //    private Transform target;

    //    void Start()
    //    {
    //        animator = GetComponent<Animator>();
    //        target = rightPlayer;
    //    }

    //    void Update()
    //    {
    //        if (Input.GetKeyDown(KeyCode.LeftArrow))
    //        {
    //            animator.SetTrigger("LeftMove");
    //            target = leftPlayer;
    //        }
    //        if (Input.GetKeyDown(KeyCode.RightArrow))
    //        {
    //            animator.SetTrigger("RightMove");
    //            target = rightPlayer;
    //        }
    //    }

    //    public void EnableCollider()
    //    {
    //        bool isEnabled = GetComponent<BoxCollider>().enabled;
    //        GetComponent<BoxCollider>().enabled = !isEnabled;
    //    }

    //    private Vector3 HitVelocity(Transform target, Vector3 P0)
    //    {
    //        Vector3 Pf = target.position;
    //        Vector3 g = Physics.gravity;
    //        return (Pf - P0) / hitTime - 0.5f * g * hitTime;
    //    }

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        if (other.CompareTag("Bomb"))
    //        {
    //            Vector3 P0 = other.transform.position;
    //            Vector3 hitVelocity = HitVelocity(target, P0);
    //            Vector3 randomTorque = 100f * Random.onUnitSphere;

    //            other.GetComponent<Rigidbody>().velocity = hitVelocity;
    //            other.GetComponent<Rigidbody>().AddTorque(randomTorque, ForceMode.Impulse);
    //        }
    //    }
}
