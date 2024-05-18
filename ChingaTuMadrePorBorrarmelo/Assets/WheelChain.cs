using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChain : MonoBehaviour
{
    public GameObject LinkPrefab;
    public int LinkCount;

    float input;
    void Start()
    {
        CreateLinks();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("VerticalWASD");

 

        foreach (Transform child in transform)
        {
            child.GetComponent<WheelLink>().t += input * Time.deltaTime;
        }

    }
    void CreateLinks()
    {
        for (int i = 0; i < LinkCount; i++)
        {
            GameObject Link = Instantiate(LinkPrefab, transform);
            Link.GetComponent<WheelLink>().width = 2;
            Link.GetComponent<WheelLink>().height = 0.75f;
            Link.GetComponent<WheelLink>().phi = i * 2 * Mathf.PI / LinkCount;
        }
    }
}
