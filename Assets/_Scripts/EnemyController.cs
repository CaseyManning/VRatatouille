using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    public float sightRange = 6f;
    public float collideDist = 1.5f;

    Animator anim;
    NavMeshAgent nav;

    bool lostSight = false;
    float lostSightTime = 0;

    public Vector3 startPos;

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
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Idle)
        {
            nav.SetDestination(startPos);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position) + Vector3.up, out hit, 20f))
            {
                Debug.DrawLine(transform.position, hit.point);
                print(hit.collider.tag);
                if (hit.collider.CompareTag("Player"))
                {
                    anim.SetTrigger("Walk");
                    state = EnemyState.Following;
                }
            }
        }
        if(state == EnemyState.Following)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, (player.transform.position - transform.position + Vector3.up), out hit, 20f))
            {
                if(!hit.collider.CompareTag("Player") && !lostSight)
                {
                    lostSight = true;
                    lostSightTime = Time.time;
                }
                if(hit.collider.CompareTag("Player") && lostSight)
                {
                    lostSight = false;
                }
            }
            if(lostSight && Time.time - lostSightTime > 1f)
            {
                anim.SetTrigger("Idle");
                state = EnemyState.Idle;
                lostSight = false;
            }
            nav.SetDestination(player.transform.position);
            if(Vector3.Distance(player.transform.position, transform.position) < collideDist)
            {
                anim.SetTrigger("Idle");
                resetScene();
                state = EnemyState.Idle;
            }
        }
    }

    public void move()
    {
        anim.SetTrigger("Walk");
        nav.SetDestination(transform.GetChild(0).transform.position);
        StartCoroutine(delayedRemove());
    }
    IEnumerator delayedRemove()
    {
        yield return new WaitForSeconds(10);
        anim.SetTrigger("Idle");
        state = EnemyState.Idle;
    }

    void resetScene()
    {
        player.transform.position = new Vector3(15.4f, 0, 15.4f);
        foreach(GameObject enem in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyController cont = enem.GetComponent<EnemyController>();
            enem.transform.position = cont.startPos;
            cont.state = EnemyState.Idle;
            cont.anim.SetTrigger("Idle");
            cont.nav.SetDestination(cont.startPos);
        }
    }
}
