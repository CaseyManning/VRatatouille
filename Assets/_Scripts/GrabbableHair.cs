using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableHair : MonoBehaviour
{
    public bool beingGrabbed;
    public GameObject anchorBone;

    public GameObject headAnchor;

    Vector3 pos;
    Vector3 boneStart;
    Quaternion boneStartRot;
    Vector3 boneOriginal;
    Quaternion boneOriginalRot;

    // Start is called before the first frame update
    void Start()
    {
        pos = headAnchor.transform.InverseTransformPoint(transform.position);
        boneOriginal = anchorBone.transform.localPosition;
        boneOriginalRot = anchorBone.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headAnchor.transform.TransformPoint(pos);
    }

    public void resetPos()
    {
        boneStart = anchorBone.transform.localPosition;
        boneStartRot = anchorBone.transform.localRotation;
        StartCoroutine(lerpBack());
    }

    IEnumerator lerpBack()
    {
        for (float i = 0; i <= 100; i+= 5)
        {
            anchorBone.transform.localPosition = Vector3.Lerp(boneStart, boneOriginal, i/100f);
            anchorBone.transform.localRotation = Quaternion.Lerp(boneStartRot, boneOriginalRot, i / 100f);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
