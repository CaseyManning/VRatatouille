using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandButton : MonoBehaviour
{
    public UnityEvent onPress;

    Vector3 pushVec = new Vector3(0.1f, 0, 0);

    Vector3 start;
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(start.x, start.y, transform.localPosition.z);
        print(transform.localPosition.z);
        if (transform.localPosition.z < start.z - 0.04f)
        {
            transform.localPosition = start + new Vector3(0, 0, -0.04f);
            if (!pressed)
            {
                print("pressing button");
                pressed = true;
                onPress.Invoke();
                if (RatHandsController.leftGrab) {
                    OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
                } else
                {
                    OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
                }
                StartCoroutine(stopVibrate());
            }
        }
        if (transform.localPosition.z > start.z)
        {
            transform.localPosition = start;
        }
    }
    IEnumerator stopVibrate()
    {
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.All);
    }
}
