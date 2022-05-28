using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    float moveDist = 12f;
    float rotAmt = 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open()
    {
        StartCoroutine(opening());
    }

    public void swingOpen()
    {
        StartCoroutine(swinging());
    }

    IEnumerator opening()
    {
        while(moveDist > 0)
        {
            float move = Time.deltaTime * 1.5f;

            transform.position += Vector3.down * move;
            moveDist -= move;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator swinging()
    {
        while (rotAmt > 0)
        {
            float rot = Time.deltaTime * 15f;

            transform.Rotate(new Vector3(0, -rot, 0));
            rotAmt -= rot;
            yield return new WaitForEndOfFrame();
        }
    }
}
