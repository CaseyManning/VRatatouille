using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    float moved = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeDoors()
    {
        StartCoroutine(closing());
    }

    IEnumerator closing()
    {
        while (moved < 1.9f)
        {
            float move = Time.deltaTime / 2f;
            moved += move;
            leftDoor.transform.position -= Vector3.right * move;
            rightDoor.transform.position += Vector3.right * move;

            yield return new WaitForEndOfFrame();
        }
    }
}
