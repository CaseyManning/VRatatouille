using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAud1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(playTut());
    }

    IEnumerator playTut()
    {
        yield return new WaitForSeconds(10f);
        GetComponent<AudioSource>().Play();
    }
}
