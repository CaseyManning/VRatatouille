using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerNavMeshSnap : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] anchors;
    Animator anim;

    public float snapRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool snapping = false;
        if(!RatHandsController.leftGrab && !RatHandsController.rightGrab)
        {
            anchors = GameObject.FindGameObjectsWithTag("PlayerAnchor");
            foreach(GameObject anchor in anchors)
            {
                float dist = Vector3.Distance(transform.position, anchor.transform.position);
                if (dist < snapRange && dist > 0.1f)
                {
                    agent.enabled = true;
                    anim.SetBool("Walking", false);
                    agent.SetDestination(anchor.transform.position);
                    snapping = true;
                }
            }
        }
        if(!snapping)
        {
            agent.enabled = false;
        }
    }
}
