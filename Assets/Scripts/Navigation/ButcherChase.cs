using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
public class ButcherChase : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if ((transform.position - target.transform.position).magnitude > 1.1f)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
