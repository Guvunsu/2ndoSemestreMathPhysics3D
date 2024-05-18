using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmonicOscilator : MonoBehaviour
{

    public Transform mass;
    public Spring spring;
    public float amplitud;
    public float frequency;
    public float phase;
    public float lenght;
    private float t;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        mass.localPosition = PositionFunction();
        spring.lenght = mass.localPosition.y;
        mass.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, (mass.localPosition.y - lenght) / amplitud);
    }
    Vector3 PositionFunction()
    {
        float y = lenght * amplitud * Mathf.Sin(frequency * t - phase);
        return new Vector3(0, y, 0);
    }
}
