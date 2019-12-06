using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour {

	NavMeshAgent nm;
	public Transform target;
    public float chasingDistance = 7f;
    public float attackingDistance = 1.5f;
    public enum AIstate { idle, chasing, attacking}
    public AIstate state = AIstate.idle;
    public Animator animator;

	// Use this for initialization
	void Start () {
		nm = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
    IEnumerator Think()
    {
        while(true)
        {
            switch(state)
            {
                case AIstate.idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist < chasingDistance)
                    {
                        state = AIstate.chasing;
                        animator.SetBool("chasing", true);
                    }
                    nm.SetDestination(transform.position);
                    break;
                case AIstate.chasing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > chasingDistance)
                    {
                        state = AIstate.idle;
                        animator.SetBool("chasing", false);
                    }
                    if (dist < attackingDistance) 
                    {
                        state = AIstate.attacking;
                        animator.SetBool("attacking", true);
                    }
                    nm.SetDestination(target.position);
                    break;
                case AIstate.attacking:
                    dist = Vector3.Distance(target.position, transform.position);
                    nm.SetDestination(transform.position);
                    if (dist > attackingDistance)
                    {
                        state = AIstate.chasing;
                        animator.SetBool("attacking", false);
                    }
                    break;
                default:
                    break;
            }
            
            yield return new WaitForSeconds(0.2f);
        }
    }
}
