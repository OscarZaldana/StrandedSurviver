using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{

    public Transform pointZero;
    public GameObject image;
	// Use this for initialization
	void Start ()
    {
		  
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(pointZero.transform.position);
        float dis = Vector3.Distance(gameObject.transform.position, pointZero.position);
        if (dis > 20)
        {
            image.SetActive(true);
        }
        else
            image.SetActive(false);
    }
}
