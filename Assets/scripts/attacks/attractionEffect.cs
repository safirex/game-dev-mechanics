using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractionEffect : MonoBehaviour
{
    public float force;
    public float distanceMax;


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        pullToSelf(getObjectToPull());
    }

    ArrayList getObjectToPull()
    {
        ArrayList array= new ArrayList();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("moveable"))
        {
            if(Vector3.Distance( go.transform.position, 
                transform.position) < distanceMax){
                array.Add(go);
            }
        }

        return array;
    }


    void pullToSelf(ArrayList objectList)
    {
        Vector3 vect = transform.position;
        foreach (GameObject pulledObject in objectList)
        {
            vect = vect - pulledObject.transform.position;
            vect = Vector3.MoveTowards(pulledObject.transform.position,
                vect,
                distanceMax);
            pulledObject.transform.Translate(vect*force*Time.deltaTime);
        }
    }
}
