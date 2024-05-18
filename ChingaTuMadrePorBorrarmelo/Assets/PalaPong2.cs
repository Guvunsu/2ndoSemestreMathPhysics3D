using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaPong2 : MonoBehaviour
{
    public float paddlespeed;



    // Start is called before the first frame update
    void Start()
    {

    }

    public enum Players
    {
        Player1,
        Player2
    }

    public Players players;

    // Update is called once per frame
    void Update()
    {
        //float HiInput = Input.GetAxis("VerticalArrows");

        //Vector2 velocity = paddlespeed * new Vector2(0, HiInput);

        //GetComponent<Rigidbody2D>().velocity = velocity;

        switch (players)
        {
            case Players.Player1:
                float ViInput = Input.GetAxis("VerticalWASD");
                Vector2 velocity1 = paddlespeed * new Vector2(0, ViInput);
                GetComponent<Rigidbody2D>().velocity = velocity1;
                break;
            case Players.Player2:
                float ViInput2 = Input.GetAxis("VerticalArrows");
                Vector2 velocity2 = paddlespeed * new Vector2(0, ViInput2);
                GetComponent<Rigidbody2D>().velocity = velocity2;
                break;
        }
    }
}

