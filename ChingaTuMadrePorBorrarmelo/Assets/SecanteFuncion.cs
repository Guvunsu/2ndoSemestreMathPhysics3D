using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecanteFuncion : MonoBehaviour
{
    public float Xmin, Xmax, Deltax;
    List<Vector3> FunctionPoints = new List<Vector3>();

    public Transform Point1;
    public Transform Point2;
    public float x;

    public TextMesh tx;

    [Range(0.001f, 2)] public float h;
    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.15f;
        PlotFunction();

    }


    void Update()
    {
        Vector3 position1 = new Vector3(x, F1(x), 0);
        Point1.transform.position = position1;
        Vector3 position2 = new Vector3(x + h, F1(x + h), 0);
        Point2.transform.position = position2;

        Debug.DrawLine(position1, position2, Color.cyan);


        float m = (position1.y - position2.y) / (position1.x - position2.x);
        tx.text = m.ToString();
    }
    // Update is called once per frame
    void PlotFunction()
    {
        FunctionPoints.Clear();
        for (float x = Xmin; x <= Xmax; x += Deltax)

        {
            float y = F1(x);
            Vector3 FuntionPoint = new Vector3(x, y, 0);
            FunctionPoints.Add(FuntionPoint);

        }
        GetComponent<LineRenderer>().positionCount = FunctionPoints.Count;
        GetComponent<LineRenderer>().SetPositions(FunctionPoints.ToArray());
    }
    float F1(float x)
    {
        return -Mathf.Pow(x, 3) + 6 * x - 2;
    }
}
