using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonPath : MonoBehaviour
{
    public float speed;
    public Transform wayPoints;
    public float radius;
    public Vector3 randomVector;
    private int wpNum, wpIndex;
    void Start()
    {
        wpNum = wayPoints.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wayPointPosition = wayPoints.GetChild(wpIndex).position + randomVector;
        Vector3 direction = (wayPoints.GetChild(wpIndex).position - transform.position).normalized;
        transform.Translate(speed * direction * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, wayPoints.GetChild(wpIndex).position) < radius)
        {
            wpIndex++;

        }
        if (wpIndex == wpNum)
        {
            wpIndex = 0;
        }



    }
}
