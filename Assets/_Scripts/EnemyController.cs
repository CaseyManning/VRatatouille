using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    public float sightRange = 3f;
    public float collideDist = 1f;

    Animator anim;
    NavMeshAgent nav;

    enum EnemyState
    {
        Idle, Following, Disabled
    }

    EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Idle)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightRange)
            {
                anim.SetTrigger("Walk");
                state = EnemyState.Following;
            }
        }
        if(state == EnemyState.Following)
        {
            nav.SetDestination(player.transform.position);
            if(Vector3.Distance(player.transform.position, transform.position) < collideDist)
            {
                anim.SetTrigger("Idle");
                state = EnemyState.Disabled;
            }
        }
    }
}
