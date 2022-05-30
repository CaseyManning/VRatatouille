using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
        state = EnemyState.Disabled;
    }
    IEnumerator delayedRemove()
    {
        yield return new WaitForSeconds(10);
        anim.SetTrigger("Idle");
        state = EnemyState.Idle;
    }

    void resetScene()
    {
        
        RawImage fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<RawImage>();
        StartCoroutine(fadeInOut(fader));
    }

    IEnumerator fadeInOut(RawImage fade)
    {
        float n = 30f;
        for (float i = 0; i < n; i++)
        {
            fade.color = new Color(0, 0, 0, i / n);
            yield return new WaitForEndOfFrame();
        }
        foreach (GameObject enem in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyController cont = enem.GetComponent<EnemyController>();
            enem.transform.position = cont.startPos;
            cont.state = EnemyState.Idle;
            cont.anim.SetTrigger("Idle");
            cont.nav.SetDestination(cont.startPos);
            cont.nav.enabled = true;
        }
        yield return new WaitForSeconds(0.2f);
        for (float i = 0; i < n; i++)
        {
            fade.color = new Color(0, 0, 0, (n-i) / n);
            yield return new WaitForEndOfFrame();

        }
        player.transform.position = new Vector3(15.4f, 0, 15.4f);

    }

    public void die()
    {
        anim.SetTrigger("Death");
        state = EnemyState.Disabled;
        nav.enabled = false;
    }
}
