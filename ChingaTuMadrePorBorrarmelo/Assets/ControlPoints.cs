using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoints : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;


    public float SpeedPoint;
    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        float HiInput = Input.GetAxisRaw("HorizontalWASD");

        float ViInput = Input.GetAxisRaw("VerticalWASD");

        float HoInput = Input.GetAxisRaw("HorizontalArrows");

        float VoInput = Input.GetAxisRaw("VerticalArrows");

        Vector2 Direccion = new Vector2(HiInput, ViInput).normalized;
        Vector2 Direccion2 = new Vector2(HoInput, VoInput).normalized;

        Point1.Translate(SpeedPoint * Direccion * dt);
        Point2.position += SpeedPoint * (Vector3)Direccion2 * dt;

        GetComponent<LineRenderer>().SetPosition(0, Point1.position);
        GetComponent<LineRenderer>().SetPosition(1, Point2.position);

    }

    float Pendiente(Vector2 P1, Vector2 P2)
    {
        return (P1.y - P2.y) / (P1.x - P2.x);
    }
}
