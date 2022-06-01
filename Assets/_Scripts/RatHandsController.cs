using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHandsController : MonoBehaviour
{
    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;

    public GameObject leftRatBone;
    public GameObject rightRatBone;

    public GameObject leftClawBase;
    public GameObject rightClawBase;

    public GameObject leftHairRoot;
    public GameObject rightHairRoot;

    public GameObject headAnchor;

    public GameObject leftAnchor;
    public GameObject rightAnchor;

    public GameObject centerEye;

    public static GrabbableHair leftGrab = null;
    public static GrabbableHair rightGrab = null;

    float grabDist = 0.1f;

    Vector3 handPosStart;

    public static Quaternion leftRot;
    public static Quaternion rightRot;

    // Start is called before the first frame update
    void Start()
    {
        handPosStart = leftRatBone.transform.GetChild(0).transform.localPosition;

    }

    public GrabbableHair nearestHair(Vector3 pos)
    {
        GameObject[] hairs = GameObject.FindGameObjectsWithTag("HairStrand");
        GrabbableHair closest = null;
        float cDist = 9999;
        foreach(GameObject ghair in hairs)
        {
            GrabbableHair hair = ghair.GetComponent<GrabbableHair>();
            float dist = Vector3.Distance(pos, hair.anchorBone.transform.position);
            if(dist < cDist && dist < grabDist)
            {
                cDist = dist;
                closest = hair;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {

        if(OVRInput.Get(OVRInput.RawButton.LHandTrigger))
        {
            leftGrab = nearestHair(leftHandAnchor.transform.position);
            setClawGrabbed(leftRatBone);
        }
        else if(leftGrab != null)
        {
            leftGrab.resetPos();
            leftGrab = null;
        } else
        {
            setClawUngrabbed(leftRatBone);
        }
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            rightGrab = nearestHair(rightHandAnchor.transform.position);
            setClawGrabbed(rightRatBone);
        }
        else if (rightGrab != null)
        {
            rightGrab.resetPos();
            rightGrab = null;
        } else
        {
            setClawUngrabbed(rightRatBone);
        }

        leftClawBase.transform.position = leftAnchor.transform.position;
        rightClawBase.transform.position = rightAnchor.transform.position;

        leftRatBone.transform.position = leftHandAnchor.transform.position;
        rightRatBone.transform.position = rightHandAnchor.transform.position;

        if(leftGrab)
        {
            leftGrab.anchorBone.transform.position = leftHandAnchor.transform.position;
            leftGrab.anchorBone.transform.rotation = leftHandAnchor.transform.rotation;
        }
        if(rightGrab)
        {
            rightGrab.anchorBone.transform.position = rightHandAnchor.transform.position;
            rightGrab.anchorBone.transform.rotation = rightHandAnchor.transform.rotation;
        }
        //rightHairRoot.transform.position = headAnchor.transform.TransformPoint(rightHairOffset);
        //leftHairRoot.transform.position = headAnchor.transform.TransformPoint(leftHairOffset);

        leftRatBone.transform.rotation = leftHandAnchor.transform.rotation;
        leftRatBone.transform.Rotate(new Vector3(0, 180, 0));
        rightRatBone.transform.rotation = rightHandAnchor.transform.rotation;
        rightRatBone.transform.Rotate(new Vector3(0, 180, 0));

    }

    void setClawGrabbed(GameObject cbone)
    {
        //cbone.transform.GetChild(0).localPosition = new Vector3(0.1f, 0, 0);
        cbone.transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(47.10f, 154.03f, 90.00f));
        cbone.transform.GetChild(0).GetChild(0).localRotation = Quaternion.Euler(new Vector3(330.51f, 304.41f, 64.52f));
    }
    void setClawUngrabbed(GameObject cbone)
    {
        cbone.transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(47.10f, 202.53f, 90.00f));
        cbone.transform.GetChild(0).GetChild(0).localRotation = Quaternion.Euler(new Vector3(320.01f, 334.13f, 64.52f));
    }
}
