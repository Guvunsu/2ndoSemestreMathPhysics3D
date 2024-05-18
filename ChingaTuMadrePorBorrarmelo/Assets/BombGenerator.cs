using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject bombPrefab;

    private void Start()
    {
        InvokeRepeating("CreateBomb", 2, 2);
    }

    void CreateBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Destroy(bomb, 10f);
    }
}
