using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public int NumEnemies;
    public GameObject enemyShip;

    void Start()
    {
        for (int i = 0; i < NumEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyShip, transform);
            float radius = Random.Range(100f, 500f);
            float w0 = Random.Range(-0.75f, 0.75f);
            float w1 = Random.Range(0.75f, 0.75f);
            float f0 = Random.Range(-0.35f, 0.95f);
            float f1 = Random.Range(75f, 5f);
            float h = Random.Range(200, 500f);

            enemy.GetComponent<enemyShip>().r = radius;
            enemy.GetComponent<enemyShip>().w0 = w0;
            enemy.GetComponent<enemyShip>().w1 = w1;
            enemy.GetComponent<enemyShip>().f0 = f0;
            enemy.GetComponent<enemyShip>().f1 = f1;
            enemy.GetComponent<enemyShip>().h = h;



        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
