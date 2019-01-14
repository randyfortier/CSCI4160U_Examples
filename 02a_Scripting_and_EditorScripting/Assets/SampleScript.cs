using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class SampleScript : MonoBehaviour {
    public Rigidbody cannonball;

    public Vector3 offset = Vector3.forward;

    public int maxSpeed = 15;
    [HideInInspector] public int minSpeed = 0;

    private int minTurnSpeed = 0;
    [SerializeField] private int maxTurnSpeed = 8;

    [Range(0, 100)] public float velocity = 10;
}
