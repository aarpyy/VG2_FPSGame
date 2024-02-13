using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Outlets
    NavMeshAgent navAgent;
    Animator animator;

    // Configuration
    public Transform target;
    public Transform patrolRoute;
    public Transform priorityTarget;

    // State Tracking
    int patrolIndex;
    public float chaseDistance;

    // Menthods
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolRoute)
        {
            // Which patrol point is active
            target = patrolRoute.GetChild(patrolIndex);

            // How far is the patrol point?
            float distance = Vector3.Distance(transform.position, target.position);
            // print("Distance: " + distance); // DEBUG distance so we can configure a threshold.

            // Target the next point when we are close enough
            if (distance <= 2f)
            {
                patrolIndex++;
                if (patrolIndex >= patrolRoute.childCount)
                {
                    patrolIndex = 0;
                }
            }
        }

        if (priorityTarget)
        {
            // Keep track of our priority target
            float priorityTargetDistance = Vector3.Distance(transform.position, priorityTarget.position);

            // If the priority target gets too close, follow it and highlight ourselves
            if (priorityTargetDistance <= chaseDistance)
            {
                target = priorityTarget;
                // GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                // GetComponent<Renderer>().material.color = Color.white;
            }
        }

        if (target)
        {
            navAgent.SetDestination(target.position);
        }

        animator.SetFloat("velocity", navAgent.velocity.magnitude);
    }
}

