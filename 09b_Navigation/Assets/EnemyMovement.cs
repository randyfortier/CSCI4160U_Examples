using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] Transform[] waypoints;
    [SerializeField] float closeEnoughDistance;
    [SerializeField] bool loop;

    private NavMeshAgent agent;
    private Animator animator;

    private int waypointIndex = 0;
    private bool patrolling = true;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        if (agent != null) {
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }

    private void Update() {
        if (!patrolling) {
            return;
        }

        float distanceToWaypoint = Vector3.Distance(agent.transform.position, 
                                                    waypoints[waypointIndex].position);

        if (distanceToWaypoint < closeEnoughDistance) {
            // we've arrived at the waypoint

            // go to the next waypoint
            waypointIndex++;

            // loop, if desired
            if (waypointIndex >= waypoints.Length) {
                if (loop) {
                    waypointIndex = 0;
                } else {
                    patrolling = false;
                    return;
                }
            }

            if (agent != null) {
                agent.SetDestination(waypoints[waypointIndex].position);
            }
        }
        animator.SetBool("Crouch", false);
        animator.SetFloat("Forward", agent.velocity.magnitude);
        //animator.SetFloat("Turn", agent.angularSpeed);
    }
}
