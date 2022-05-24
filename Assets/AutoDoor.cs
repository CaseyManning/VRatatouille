using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    float moveDist = 12f;
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
}
