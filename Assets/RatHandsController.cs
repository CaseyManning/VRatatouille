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

    Vector3 rightBaseOffset;
    Vector3 leftBaseOffset;

    public GameObject centerEye;


    // Start is called before the first frame update
    void Start()
    {
        rightBaseOffset = rightClawBase.transform.position - centerEye.transform.position;
        leftBaseOffset = leftClawBase.transform.position - centerEye.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        leftClawBase.transform.position = centerEye.transform.position + leftBaseOffset;
        rightClawBase.transform.position = centerEye.transform.position + rightBaseOffset;

        leftRatBone.transform.position = leftHandAnchor.transform.position;
        rightRatBone.transform.position = rightHandAnchor.transform.position;

        leftRatBone.transform.rotation = leftHandAnchor.transform.rotation;
        leftRatBone.transform.Rotate(new Vector3(0, 180, 0));
        rightRatBone.transform.rotation = rightHandAnchor.transform.rotation;
        rightRatBone.transform.Rotate(new Vector3(0, 180, 0));

    }
}
