using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed = 1.5f;
    [SerializeField] private float rotationSpeed = 200.0f;

    private CharacterController controller;
    private Animator animator;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        // don't move if dead
        if (animator.GetBool("Dead")) {
            return;
        }

        // movement
        float forward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        Vector3 position = transform.position + (transform.forward * forward);
        transform.position = position;
        animator.SetFloat("Speed", forward);

        // rotation
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, rotation, 0.0f));

        // see if an attack is finishing
        float attackCompletion = animator.GetFloat("AttackCompletion");
        if (attackCompletion >= 0.95f) {
            animator.SetBool("Attacking", false);
        }

        // do we attack?
        if (Input.GetButtonDown("Fire1")) {
            animator.SetBool("Attacking", true);
        }
    }
}
