using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float lenght, radius;
    public int turns;
    List<Vector3> pointList = new List<Vector3>();
    void Start()
    {
        initialRendenderer();
    }

    // Update is called once per frame
    void Update()
    {
        updateSpringPoints();
    }
    void initialRendenderer()
    {
        GetComponent<LineRenderer>().useWorldSpace = false;
        GetComponent<LineRenderer>().widthMultiplier = 0.05f; //usar esto en el cubo artesanal
    }
    void updateSpringPoints()
    {
        pointList.Clear();
        float pi = Mathf.PI;
        for (float s = 0f; s <= 2f * pi; s += 0.025f)
        {
            Vector3 point = springShape(s);
            pointList.Add(point);
        }
        GetComponent<LineRenderer>().positionCount = pointList.Count;
        GetComponent<LineRenderer>().SetPositions(pointList.ToArray());
    }
    Vector3 springShape(float s)
    {
        float pi = Mathf.PI;
        float x = radius * Mathf.Cos(turns * s);
        float y = s * lenght / (2 * pi);
        float z = radius * Mathf.Sin(turns * s);
        return new Vector3(x, y, z);
    }
}
