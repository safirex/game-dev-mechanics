using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(cam.transform);
    }
}
