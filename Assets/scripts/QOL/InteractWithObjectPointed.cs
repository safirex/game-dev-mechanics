using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Meant for thing like camera or something*/
public class InteractWithObjectPointed : MonoBehaviour
{

    public Camera camera;

    void Start()
    {
        Debug.Log("raycasting");
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log("halp");
            // Do something with the object that was hit by the raycast.
        }
    }
}
