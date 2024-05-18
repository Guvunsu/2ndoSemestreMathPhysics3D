using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;

public class SectorBehaviour : MonoBehaviour
{
    public float repeatTime;
    public AnimatorController animatorController;
    public bool chooseSector
        ;
    public static int index;
    public static bool selectionActive;
    public static List<Transform> sectors = new List<Transform>();
    private Color originalColor;

    void Start()
    {
        selectionActive = true;
        foreach (Transform child in transform)
        {
            sectors.Add(child.GetChild(0));
        }
        originalColor = sectors[0].GetComponent<MeshRenderer>().material.color;
        StartCoroutine(waitAndChange());
    }

    // Update is called once per frame
    void Update()
    {
        if (chooseSector)
        {
            chooseSector = false;
            selectionActive = false;
            sectors[index].GetComponent<Animator>().runtimeAnimatorController = animatorController;
            sectors[index].GetComponent<Animator>().SetTrigger("Move");
        }
    }
    public static void removeAnimator()
    {
        selectionActive = true;

    }
    private void changeIndex()
    {
        index++;
        if (index == sectors.Count)
        {
            index = 0;
        }
    }
    private void SetColors()
    {
        for (int i = 0; index < sectors.Count; i++)
        {
            if (i == index)
            {
                sectors[i].GetComponent<MeshRenderer>().material.color = Color.red;

            }
            else
            {
                sectors[i].GetComponent<MeshRenderer>().material.color = originalColor;
            }
        }
    }
    private IEnumerator waitAndChange()
    {
        while(true)
        {
            if (selectionActive)
            {
                changeIndex();
                SetColors();
            }
            yield return new WaitForSeconds(repeatTime);
        }
    }
}
