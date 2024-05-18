using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationGenerator : MonoBehaviour
{
    [System.NonSerialized]
    public static List<List<int>> allCombinations = new List<List<int>>();

    private void Awake()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < 52; i++)
            numbers.Add(i);

        int k = 5;  // Número de elementos en cada combinación

        GenerateCombinations(numbers, k);

        // Imprimir las combinaciones almacenadas (opcional)
        //foreach (var combination in allCombinations)
        //{
        //    Debug.Log(string.Join(", ", combination));
        //}
    }

    private void GenerateCombinations(List<int> numbers, int k, int start = 0, List<int> path = null)
    {
        if (path == null)
        {
            path = new List<int>();
        }

        if (path.Count == k)
        {
            List<int> newCombination = new List<int>(path);
            allCombinations.Add(newCombination);
            return;
        }

        for (int i = start; i < numbers.Count; i++)
        {
            if (!path.Contains(numbers[i]))
            {
                path.Add(numbers[i]);
                GenerateCombinations(numbers, k, i + 1, path);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
