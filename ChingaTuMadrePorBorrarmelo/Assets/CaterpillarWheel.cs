using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarWheel : MonoBehaviour
{
    public GameObject eslabonPrefab;
    public int NumEslabon;
    void Start()
    {
        for (int i = 0; i < NumEslabon; i++)
        {
            GameObject eslabon = Instantiate(eslabonPrefab, transform);
            eslabon.GetComponent<Eslabon>().a = 5;
            eslabon.GetComponent<Eslabon>().b = 1;
            eslabon.GetComponent<Eslabon>().w = 1;
            eslabon.GetComponent<Eslabon>().f = i * 2f * Mathf.PI / NumEslabon;
        }

    }

   

    // Update is called once per frame
    void Update()
    {
    }
}
