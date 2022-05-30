using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HandGrabbable"))
        {
            print(transform.parent.parent.parent.parent.parent.parent.parent.gameObject.name);
            EnemyController enemy = transform.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<EnemyController>();
            enemy.die();
        }
    }
}
