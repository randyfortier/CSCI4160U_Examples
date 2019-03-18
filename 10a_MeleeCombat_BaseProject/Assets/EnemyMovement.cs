using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float alertDistance = 10.0f;
    [SerializeField] private float attackDistance = 1.0f;

    private Animator animator;
    private NavMeshAgent agent;

    void Awake() {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        // don't move if we're dead
        if (animator.GetBool("Dead")) {
            return;
        }

        Vector3 direction = target.position - transform.position;
        //direction.y = 0.0f; // don't rotate up/down

        if (direction.magnitude < attackDistance) {
            // we're close enough to attack, so do it

            // don't navigate
            agent.enabled = false;

            // start attack animation
            animator.SetBool("Attacking", true);

            // turn toward the target
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.1f);
        } else if (direction.magnitude < alertDistance) {
            // we're close enough to see the target, to move toward it

            // navigate toward the target
            agent.SetDestination(target.position);
            agent.enabled = true;

            // start the animation
            animator.SetFloat("Speed", agent.velocity.magnitude);
            animator.SetBool("Attacking", false); // disable any attack while moving
        }
    }
}
