using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public static int monitorsSmashed = 0;

    bool shattered = false;

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
        if(other.tag == "HandGrabbable" && !shattered)
        {
            shatter();
            shattered = true;
            monitorsSmashed += 1;
            GetComponent<AudioSource>().Play();
            if(monitorsSmashed == 2)
            {
                AudioPlayer.play(AudioPlayer.Clips.monitorsDialogue2);
                //Destroy(GameObject.FindGameObjectWithTag("Hammer"));
            }
            if(RatHandsController.leftGrab)
            {
                OVRInput.SetControllerVibration(0.5f, 0.8f, OVRInput.Controller.LTouch);
            } else
            {
                OVRInput.SetControllerVibration(0.5f, 0.8f, OVRInput.Controller.RTouch);
            }
            StartCoroutine(stopVibrate());
        }
    }
    IEnumerator stopVibrate()
    {
        yield return new WaitForSeconds(0.15f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.All);
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
