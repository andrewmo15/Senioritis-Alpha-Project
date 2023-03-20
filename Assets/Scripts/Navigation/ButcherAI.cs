using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static AreaReporter;

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
    private AreaReporter targetAreaReporter;

    public GameObject target;
    public GameObject[] hallwayWaypoints;
    public int waypointIndex = -1;

    public GameObject room1Waypoint;
    public GameObject room2Waypoint;
    public GameObject room3Waypoint;
    public GameObject room4Waypoint;

    // State machine
    private AIState prevState;
    public AIState state;

    private readonly float detectionRadius = 10.0f;
    private readonly float catchRadius = 1.0f;
    private readonly float chaseDuration = 10.0f;
    private readonly float cooldownDuration = 5.0f;

    // Chase timer
    public float timeRemaining = 0.0f;
    public float cooldownRemaining = 0.0f;

    public AudioSource audioSource;
    public AudioClip normalBGM;
    public AudioClip chaseBGM;

    private Area TargetArea  // Returns the Area of the target
    {
        get
        {
            return targetAreaReporter.CurrentArea;
        }
    }

    void Start()
    {
        if (hallwayWaypoints.Length <= 0)
        {
            Debug.LogError("Hallway Waypoints array is empty");
        }

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targetAreaReporter = target.GetComponent<AreaReporter>();

        prevState = AIState.Idle;
        state = AIState.Hallway;
    }

    void Update()
    {
        switch (state)
        {
            case (AIState.Idle):
                {
                    // If target is within detection distance, switch to Chase state
                    float distanceToTarget = (target.transform.position - transform.position).magnitude;
                    if (distanceToTarget <= detectionRadius && cooldownRemaining <= 0.0f)
                    {
                        prevState = AIState.Idle;
                        state = AIState.Chase;
                        break;
                    }

                    if (cooldownRemaining > 0.0f)  // Update cooldown if necessary
                    {
                        cooldownRemaining -= Time.deltaTime;
                    }

                    agent.ResetPath();  // Clear previous path if set

                    anim.SetBool("move", false);
                    anim.SetBool("run", false);

                    prevState = AIState.Idle;
                    break;
                }
            case (AIState.Hallway):  // AI patrols Hallway area using path of waypoints
                {
                    anim.SetBool("run", false);

                    // If target is within detection distance, switch to Chase state
                    float distanceToTarget = (target.transform.position - transform.position).magnitude;
                    if (TargetArea == Area.Hallway && distanceToTarget <= detectionRadius && cooldownRemaining <= 0.0f)
                    {
                        prevState = AIState.Hallway;
                        state = AIState.Chase;
                        break;
                    }

                    if (cooldownRemaining > 0.0f)  // Update cooldown if necessary
                    {
                        cooldownRemaining -= Time.deltaTime;
                    }

                    // Otherwise, move to next waypoint based on previous state                    
                    if (prevState == AIState.Hallway)  // If previous state was Hallway, move to the next Hallway waypoint
                    {
                        if (agent.pathPending == false && agent.remainingDistance - agent.stoppingDistance <= 0.0f)
                        {
                            waypointIndex = (waypointIndex + 1) % hallwayWaypoints.Length;
                            agent.SetDestination(hallwayWaypoints[waypointIndex].transform.position);
                        }
                    }
                    else  // Else, move to the closest Hallway waypoint
                    {
                        int closestIndex = 0;
                        float closestDistance = (hallwayWaypoints[closestIndex].transform.position - transform.position).magnitude;
                        for (int i = 1; i < hallwayWaypoints.Length; i++)
                        {
                            GameObject currentWaypoint = hallwayWaypoints[i];
                            float distanceToWaypoint = (currentWaypoint.transform.position - transform.position).magnitude;
                            if (distanceToWaypoint < closestDistance)
                            {
                                closestIndex = i;
                                closestDistance = distanceToWaypoint;
                            }
                        }
                        waypointIndex = closestIndex;
                        agent.SetDestination(hallwayWaypoints[waypointIndex].transform.position);
                        prevState = AIState.Hallway;
                    }
                    break;
                }
            case (AIState.Chase):  // AI chases after target until certain conditions are met
                {
                    anim.SetBool("run", true);

                    // Use timer to end chase after specific duration has elapsed
                    if (prevState != AIState.Chase)  
                    {
                        audioSource.clip = chaseBGM;
                        audioSource.time = 8.0f;
                        audioSource.Play();
                        timeRemaining = chaseDuration;  // Set timer
                    }
                    else
                    {
                        timeRemaining -= Time.deltaTime;  // Update timer
                        if (timeRemaining <= 0.0f)
                        {
                            cooldownRemaining = cooldownDuration;
                            prevState = AIState.Chase;
                            state = AIState.Hallway;
                            audioSource.clip = normalBGM;
                            audioSource.Play();
                            break;
                        }
                    }

                    float distanceToTarget = (target.transform.position - transform.position).magnitude;

                    // End game if target is caught
                    if (distanceToTarget <= catchRadius)
                    {
                        SceneManager.LoadScene("GameOver");
                    }

                    // Do simple target path prediction
                    float lookAheadTime = Mathf.Clamp(distanceToTarget / agent.speed, 0.0f, 1.0f);
                    Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
                    Vector3 futureTarget = target.transform.position + (lookAheadTime * targetRigidbody.velocity);

                    agent.SetDestination(futureTarget);
                    prevState = AIState.Chase;

                    break;
                }
        }
    }
}
