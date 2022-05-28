using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLocomotion : MonoBehaviour
{
    public float rotDeadZone = 0.15f;
    public float moveDeadZone = 0.05f;

    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;

    public GameObject centerAnchor;

    public float rotSpeed = 20f;
    public float moveSpeed = 10f;

    public Animator anim;

    public ArmIK armIK;

    Vector3 lastPosLeft;
    Vector3 lastPosRight;

    public GameObject handBone_L;
    public GameObject handBone_R;

    public static bool moved = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        lastPosLeft = leftHandAnchor.transform.position;
        lastPosRight = rightHandAnchor.transform.position;

        rb = transform.parent.parent.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RatHandsController.leftRot = handBone_L.transform.parent.rotation;
        RatHandsController.rightRot = handBone_R.transform.parent.rotation;

        rb.angularVelocity = Vector3.zero;

        anim.SetBool("Walking", false);
        if (RatHandsController.leftGrab && RatHandsController.rightGrab)
        {
            if (armIK.m_Graph.IsPlaying())
            {
                armIK.m_Graph.Stop();
                anim.playableGraph.Play();
                armIK.resetAnchors();
            }

            Vector3 left = centerAnchor.transform.InverseTransformPoint(leftHandAnchor.transform.position);
            Vector3 right = centerAnchor.transform.InverseTransformPoint(rightHandAnchor.transform.position);

            float rotationAmt = (left.x + right.x) / 2;

            if (Mathf.Abs(rotationAmt) > rotDeadZone)
            {
                //transform.parent.parent.Rotate(new Vector3(0, rotationAmt * Time.deltaTime * rotSpeed, 0));
                rb.angularVelocity = new Vector3(0, rotationAmt * rotSpeed / 50f, 0);
                anim.SetBool("Walking", true);
            }
            float moveAmt = (left.z + right.z) / 2;
            if (Mathf.Abs(moveAmt) > moveDeadZone)
            {
                moved = true;
                if (rb)
                {
                    rb.velocity = transform.forward * moveSpeed * moveAmt;
                }
                else
                {
                    transform.parent.parent.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime * moveAmt));
                }
                anim.SetBool("Walking", true);
            }

        } else if (RatHandsController.leftGrab)
        {
            armIK.m_Graph.Play();
            armIK.effector_L.transform.localPosition += (leftHandAnchor.transform.localPosition - lastPosLeft)* 5;

            lastPosLeft = leftHandAnchor.transform.localPosition;
            print(RatHandsController.leftRot);
            //armIK.effector_R.transform.rotation = RatHandsController.leftRot;


        } else if (RatHandsController.rightGrab)
        {
            armIK.m_Graph.Play();

            armIK.effector_R.transform.localPosition += (rightHandAnchor.transform.localPosition - lastPosRight) * 5;

            //armIK.effector_R.transform.rotation = RatHandsController.rightRot;
            lastPosRight = rightHandAnchor.transform.localPosition;

        } else
        {
            if(armIK.m_Graph.IsPlaying())
            {
                armIK.m_Graph.Stop();
                anim.playableGraph.Play();
                armIK.resetAnchors();
            }
        }

    }
}
