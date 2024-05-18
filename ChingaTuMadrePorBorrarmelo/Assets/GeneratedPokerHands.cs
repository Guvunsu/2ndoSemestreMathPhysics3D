using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedPokerHands : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer[] spriteRenderes;
  
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int numCombination = CombinationGenerator.allCombinations.Count;
            int handIndex = Random.Range(0, numCombination);
            List<int> cardIndex = CombinationGenerator.allCombinations[handIndex];
            for (int i = 0; i < cardIndex.Count; i++)
            {
                spriteRenderes[i].sprite = sprites[cardIndex[i]];
            }
        }
    }
}
