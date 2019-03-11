using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private Animator animator;

    [SerializeField] float runSpeed = 1.0f;
    [SerializeField] float turnSpeed = 1.0f;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        var x = Input.GetAxis("Horizontal") * turnSpeed;
        var y = Input.GetAxis("Vertical") * runSpeed;

        animator.SetFloat("Forward", y);
        animator.SetFloat("Turn", x);

        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("Melee");
        } else if (Input.GetButtonDown("Fire2")) {
            animator.SetTrigger("Cast");
        }
    }
}
