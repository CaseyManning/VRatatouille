using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyHole : MonoBehaviour
{
    public GameObject key;

    public UnityEvent unlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(key.transform.position, transform.position) < 1f)
        {
            unlock.Invoke();
            Destroy(key);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
