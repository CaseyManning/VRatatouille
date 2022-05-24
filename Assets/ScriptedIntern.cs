using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptedIntern: MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, new Vector3(-0.5f, 0, 3.3f)) < 0.5f)
        {
            GetComponent<Animator>().SetTrigger("Idle");
            agent.enabled = false;
            Vector3 rots = transform.rotation.eulerAngles;
            transform.LookAt(Camera.main.transform.position);
            transform.rotation = Quaternion.Euler(rots.x, transform.rotation.eulerAngles.y, rots.z);
        }
    }

    public void enter()
    {
        agent.SetDestination(new Vector3(-0.5f, 0, 3.3f));
        GetComponent<Animator>().SetTrigger("Walk");

    }
}
