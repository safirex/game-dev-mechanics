using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRocketSpray : MonoBehaviour
{
    public List<GameObject> subRocket;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            subRocket.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > 0.5)
        {
            foreach (GameObject miniRocket in subRocket)
            {
                miniRocket.transform.Translate(Vector3.up);
            }
        }   
    }
}
