using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPong : MonoBehaviour
{

    public Vector2 initialVelocity;
    public int p1 = 0;
    public int p2 = 0;
    public int scoreP1, scoreP2;
    public TextMesh[] textMeshes;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = initialVelocity;

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
            Debug.Log("contact");

        if (collision.collider.CompareTag("P1"))
        {
            scoreP1++;
            textMeshes[0].text = scoreP2.ToString();
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = initialVelocity;
            Debug.Log("puntuacion 1 ");

        }
        if (collision.collider.CompareTag("p2"))
        {
            // GetComponent<Rigidbody2D>().position = Vector2.zero;
            scoreP1++;
            textMeshes[1].text = scoreP1.ToString();
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = initialVelocity;
            Debug.Log("puntuacion 2 ");

        }
    }

}
