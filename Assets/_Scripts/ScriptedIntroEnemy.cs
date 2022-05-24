using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptedIntroEnemy : MonoBehaviour
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
        
    }

    public void leave()
    {
        agent.SetDestination(new Vector3(-12, 0, -2));
        GetComponent<Animator>().SetTrigger("Walk");
    }
}
