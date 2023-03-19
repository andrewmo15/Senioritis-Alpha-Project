using UnityEngine;
using UnityEngine.AI;
using static ButcherAI;
using UnityEngine.Profiling;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class ButcherAI : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Hallway,
        Room1,
        Room2,
        Room3,
        Room4,
        Chase
    }

    private NavMeshAgent agent;
    private Animator anim;

    public GameObject character;
    public GameObject[] hallwayWaypoints;
    public int currHallwayWaypoint = -1;

    public AIState state;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        state = AIState.Hallway;
}

    void Update()
    {
        switch (state)
        {
            case (AIState.Idle):
                anim.SetBool("move", false);
                anim.SetFloat("velx", 0.0f);
                anim.SetFloat("vely", 0.0f);
                break;
            case (AIState.Hallway):
                if (agent.pathPending == false && agent.remainingDistance - agent.stoppingDistance <= 0.0f)
                {
                    currHallwayWaypoint = (currHallwayWaypoint + 1) % hallwayWaypoints.Length;
                    agent.SetDestination(hallwayWaypoints[currHallwayWaypoint].transform.position);
                }
                break;
            case (AIState.Chase):
                float distance = (character.transform.position - transform.position).magnitude;
                float lookAheadTime = Mathf.Clamp(distance / agent.speed, 0.0f, 1.0f);
                Rigidbody characterRigidbody = character.GetComponent<Rigidbody>();
                Vector3 futureTarget = character.transform.position + (lookAheadTime * characterRigidbody.velocity);

                agent.SetDestination(futureTarget);

                /*if (agent.pathPending == false && distance - agent.stoppingDistance <= 0.0f)
                {
                    state = AIState.Idle;
                }*/
                break;
        }
    }
}
