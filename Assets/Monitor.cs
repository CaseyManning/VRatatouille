using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HandGrabbable")
        {
            shatter();
        }
    }

    void shatter()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            g.GetComponent<Rigidbody>().freezeRotation = false;
            g.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
