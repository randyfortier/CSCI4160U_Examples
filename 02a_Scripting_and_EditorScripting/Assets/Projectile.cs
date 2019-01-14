using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    public new Rigidbody rigidbody;  // new -> intentionally overriding parent class' field
    
    /* [Range(1, 25)] */
    public int damageRadius = 1;

    void Reset() {
        rigidbody = GetComponent<Rigidbody>();
    }
}