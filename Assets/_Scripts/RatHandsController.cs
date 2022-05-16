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

    Vector3 rightBaseOffset;
    Vector3 leftBaseOffset;

    Vector3 rightHairOffset;
    Vector3 leftHairOffset;

    public GameObject centerEye;


    // Start is called before the first frame update
    void Start()
    {
        //rightHairOffset = headAnchor.transform.InverseTransformPoint(rightHairRoot.transform.position);
        //leftHairOffset = headAnchor.transform.InverseTransformPoint(leftHairRoot.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        leftClawBase.transform.position = leftAnchor.transform.position;
        rightClawBase.transform.position = rightAnchor.transform.position;

        leftRatBone.transform.position = leftHandAnchor.transform.position;
        rightRatBone.transform.position = rightHandAnchor.transform.position;

        //rightHairRoot.transform.position = headAnchor.transform.TransformPoint(rightHairOffset);
        //leftHairRoot.transform.position = headAnchor.transform.TransformPoint(leftHairOffset);

        leftRatBone.transform.rotation = leftHandAnchor.transform.rotation;
        leftRatBone.transform.Rotate(new Vector3(0, 180, 0));
        rightRatBone.transform.rotation = rightHandAnchor.transform.rotation;
        rightRatBone.transform.Rotate(new Vector3(0, 180, 0));

    }
}
