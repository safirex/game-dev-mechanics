using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraAOE : MonoBehaviour
{

    public float size;
    public GameObject aura;

    private void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        aura.transform.position = transform.position;
    }

    public void effect()
    {

    }
}
