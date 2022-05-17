using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLocomotion : MonoBehaviour
{
    public float rotDeadZone = 0f;
    public float moveDeadZone = 0.05f;

    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;

    public GameObject centerAnchor;

    public float rotSpeed = 20f;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RatHandsController.leftGrab && RatHandsController.rightGrab)
        {
            Vector3 left = centerAnchor.transform.InverseTransformPoint(leftHandAnchor.transform.position);
            Vector3 right = centerAnchor.transform.InverseTransformPoint(rightHandAnchor.transform.position);

            float rotationAmt = left.z - right.z;

            if (Mathf.Abs(rotationAmt) > rotDeadZone)
            {
                transform.parent.Rotate(new Vector3(0, rotationAmt * Time.deltaTime * rotSpeed, 0));
            }
            float moveAmt = (left.z + right.z) / 2;
            if (Mathf.Abs(moveAmt) > moveDeadZone)
            {
                transform.parent.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime * moveAmt));
            }
        }
    }
}
