using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTargets : MonoBehaviour
{

    //setRandomTargets este es para darle un numero random de gameobjects para mis objetivos , el otro TargetRandomMOvement es para darle una posicion y movimeinto aleatorio 


    public float targetSpeed;
    private float dt;
    private float range;
    public int NumsPrefabs;

    public GameObject Target;

    //private Vector3 movementHits;
    //private Vector3 NextPosition;
    //private Quaternion moveRotation;


    void Start()
    {
        for (int i = 0; i < NumsPrefabs; i++)
        {
            float x = Random.Range(-range, range);
            float z = Random.Range(-range, range);
            float y = Random.Range(-range, range);
            Vector3 position = new Vector3(x, y, z);
            Instantiate(Target, position, Quaternion.identity);

        }

    }

    // Update is called once per frame
    void Update()
    {


        //if (Target)
        //{
        //    dt = Time.deltaTime;
        //    movementHits = Target.transform.position;
        //    moveRotation = Quaternion.LookRotation(Vector3.up, Vector3.forward);
        //  if (Vector3.Distance (NextPosition.position )
        //    {
        //        movementHits = RandomPosition();
        //    }


        //}


        //{
        //}
    }
}
