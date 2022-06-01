using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
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
        if(other.CompareTag("HandGrabbable"))
        {
            EnemyController enemy = transform.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<EnemyController>();
            enemy.die();

            if (RatHandsController.leftGrab)
            {
                OVRInput.SetControllerVibration(0.2f, 0.8f, OVRInput.Controller.LTouch);
            }
            else
            {
                OVRInput.SetControllerVibration(0.2f, 0.8f, OVRInput.Controller.RTouch);
            }
            StartCoroutine(stopVibrate());

            transform.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<AudioSource>().Play();

        }
    }
    IEnumerator stopVibrate()
    {
        yield return new WaitForSeconds(0.15f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.All);
    }
}
