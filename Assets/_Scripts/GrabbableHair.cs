using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableHair : MonoBehaviour
{
    public bool beingGrabbed;
    public GameObject anchorBone;

    public GameObject headAnchor;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = headAnchor.transform.InverseTransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headAnchor.transform.TransformPoint(pos);
    }
}
