using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapling : MonoBehaviour
{

    private int accelaration = 1;

    //TODO: a changer en fonction de la pos du grapin
    private Vector3 deplacement = new Vector3(0, 0, 1);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(deplacement*accelaration*Time.deltaTime);
        if (accelaration < 30 && Time.frameCount%30==0)
            accelaration++;
    }
}
