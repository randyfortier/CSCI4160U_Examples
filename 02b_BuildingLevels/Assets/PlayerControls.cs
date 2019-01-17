using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float jumpSpeed = 5.0f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float horiz = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horiz, 0.0f, 0.0f));
    }
}
