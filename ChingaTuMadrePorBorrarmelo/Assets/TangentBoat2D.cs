using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentBoat2D : MonoBehaviour
{
    [Range(-10f, 10f)]
    public float x;

    public Transform Boat2D;
    List<Vector3> functionPoints = new List<Vector3>();
    float time;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 pos = new Vector3(x, F2(x - time), 0);
        Boat2D.position = pos; // para darle la version de angulos
        float slope = df(x - time); //slope pendiente en español 
        float angle = Mathf.Rad2Deg * Mathf.Atan(slope);
        Boat2D.rotation = Quaternion.Euler(0, 0, angle);
        

    }
    void PlotFunction()
    {
        float Xmin = -10f;
        float Xmax = 10f;
        float deltaX = 0.1f;
        functionPoints.Clear();
        for (float x = Xmin; x <= Xmax; x += deltaX) //si le pongo el x++ hace que cada recta sea 1 +1 y el otro hace que sea 0.1 +0.1 y se ve mas fluido 
        {
            float y = F2(x - time);
            Vector3 functionPoint = new Vector3(x, y, 0);
            functionPoints.Add(functionPoint);
        }
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
        GetComponent<LineRenderer>().positionCount = functionPoints.Count;
        GetComponent<LineRenderer>().SetPositions(functionPoints.ToArray());
    }
    float F2(float x)
    {
        return Mathf.Sin(x);
    }
    float df(float x)
    {
        return Mathf.Cos(x);
    }

}
