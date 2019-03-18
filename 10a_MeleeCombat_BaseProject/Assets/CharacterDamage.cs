using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CharacterDamage : MonoBehaviour {
    [SerializeField] private Slider healthSlider;

    private Animator animator;
    private NavMeshAgent agent;

    void Awake() {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damageAmount) {
        healthSlider.value -= damageAmount;

        if (healthSlider.value <= 0.0f) {
            // we died
            animator.SetBool("Dead", true);

            if (agent != null) {
                // turn off the nav mesh agent, so we don't slide around when dead
                agent.enabled = false;
            }
        }
    }
}
