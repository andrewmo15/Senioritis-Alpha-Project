using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class ButcherNavMeshAgent : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent agent;
    private float direction;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // agent.updatePosition = false;
        // agent.updateRotation = false;

        // direction = Vector3.Angle(transform.forward, agent.desiredVelocity) * Mathf.Sign(Vector3.Dot(agent.desiredVelocity, transform.right));
        // speed = agent.desiredVelocity.magnitude;
        // anim.SetFloat("Direction", direction, 0.2f, Time.deltaTime);
        // anim.SetFloat("Speed", speed, 0.2f, Time.deltaTime);

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }    
    }
}
