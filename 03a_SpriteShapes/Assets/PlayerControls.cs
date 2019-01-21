using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float jumpSpeed = 5.0f;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded) {
            Debug.Log("Jump!");
            rb.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
        }

        transform.Translate(new Vector3(horizontalMovement, 0.0f, 0.0f));
    }
}
