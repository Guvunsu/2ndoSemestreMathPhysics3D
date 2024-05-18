using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetRandomMovement : MonoBehaviour
{
    public float range;
    public float markerSpeed;

    Vector3 nextPosition;
    Vector3 marker;
    void Start()
    {
        nextPosition = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        marker = Vector3.MoveTowards(marker, nextPosition, markerSpeed * Time.deltaTime);
        if (Vector3.Distance(marker, nextPosition) < 0.1f)
        {
            nextPosition = RandomPosition();
        }
        transform.position = marker;
    }
    Vector3 RandomPosition()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);
        float y = Random.Range(-range, range);
        return new Vector3(x, y, z);
    }
}
