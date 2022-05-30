using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabber : MonoBehaviour
{
    public GameObject holding;
    float grabDist = 0.8f;

    public HandGrabber otherHand;

    public bool left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(holding != null)
        {
            holding.transform.position = transform.position;
            return;
        }
        GameObject[] grabbables = GameObject.FindGameObjectsWithTag("HandGrabbable");
        foreach(GameObject g in grabbables)
        {
            if (Vector3.Distance(g.transform.position, transform.position) < grabDist && otherHand.holding != g)
            {
                holding = g;
                g.transform.SetParent(transform);
                g.transform.position = transform.position;
                if (left)
                {
                    holding.transform.localEulerAngles = new Vector3(0, 112, 0);
                    OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);

                }
                else
                {
                    holding.transform.localEulerAngles = new Vector3(0, -112, 0);
                    OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
                }
                StartCoroutine(stopVibrate());
            }
        }
    }
    IEnumerator stopVibrate()
    {
        yield return new WaitForSeconds(0.15f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.All);
    }
}
