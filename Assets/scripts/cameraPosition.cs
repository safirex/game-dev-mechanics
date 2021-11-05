using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    public GameObject player=null;
    public Vector3 offset = new Vector3(0, 1.09f, 3);
    public GameObject focusTarget;
    public bool focus = true;
    public Vector3 focusOffset= new Vector3(-0.18f, 0, -2.37f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position=player.transform.position+offset;
        if (focus) focusObject(focusTarget);
    }

    /** turn the camera toward the object  */
    public void focusObject(GameObject focusTarg)
    {
        
        Vector3 focusPoint = focusTarg.transform.position;
        focusPoint += focusOffset;
        transform.LookAt(focusPoint);
    }
}
