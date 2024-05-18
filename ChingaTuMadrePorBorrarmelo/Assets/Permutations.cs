using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permutations
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Factorial(5);
    }
    int Factorial(int num)
    {
        int resultado = 1;
        for (int n = 0; n < num; n++)
        {
            resultado *= Factorial(n);
        }
        return resultado;
    }

}
