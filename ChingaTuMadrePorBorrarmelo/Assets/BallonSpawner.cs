using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    public GameObject ballonPrefab;
    public float waitTime, speed, radius;
    public Transform wayPoints;
    void Start()
    {
        InvokeRepeating("SpawnBallon", 1f, waitTime);
    }

    void InvokeRepeating()
    {
        GameObject ballon = Instantiate(ballonPrefab, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void SpawnBallon()
    {
        GameObject ballon = Instantiate(ballonPrefab, transform.position, Quaternion.identity);
        ballon.GetComponent<BallonPath>().wayPoints = wayPoints;
        ballon.GetComponent<BallonPath>().speed = 3;
        Vector3 randomVector = 0.25f * Random.onUnitSphere;
        randomVector.y = 0;
        ballon.GetComponent<BallonPath>().randomVector = randomVector;
        ballon.GetComponent<BallonPath>().speed = speed;
        ballon.GetComponent<BallonPath>().radius = radius;
    }
    void Update()
    {

    }
}
