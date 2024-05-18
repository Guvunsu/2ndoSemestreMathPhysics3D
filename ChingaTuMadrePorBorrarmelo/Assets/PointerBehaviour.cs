using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehaviour : MonoBehaviour
{
    public Transform pointer;
    public Transform axisY;
    public LayerMask groundplayer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundplayer))
        {
            Vector3 grounPosition = hit.point;
            pointer.position = Vector3.Lerp(pointer.position, grounPosition, 50 + Time.deltaTime);
        }

        Vector3 direction = pointer.position - axisY.position;
        direction.y = 0;
        Quaternion newRotation = Quaternion.LookRotation(direction, Vector3.up);
        axisY.rotation = newRotation;
    }
}
