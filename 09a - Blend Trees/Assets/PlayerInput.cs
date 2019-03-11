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
    }
}
