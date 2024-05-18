using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaandomWalk : MonoBehaviour
{

    public float speed;
    public float range;
    private Vector3 nextPosition;
    void Start()
    {
        transform.position = RandomPosition();
        nextPosition = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextDirection = nextPosition - transform.position;
        Quaternion nextRotation = Quaternion.LookRotation(nextPosition, Vector3.up);
        transform.rotation = nextRotation;
        transform.position = Vector3.Lerp(transform.position, nextDirection, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPosition) < 10f)
        {
            nextPosition = RandomPosition();
        }
    }
    Vector3 RandomPosition()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);
        return new Vector3(x, 0, z);
    }
}
