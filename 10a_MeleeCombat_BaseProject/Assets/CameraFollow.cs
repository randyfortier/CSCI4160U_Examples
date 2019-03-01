using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target = null;

    void Start() {
        transform.position = target.position + offset;
    }

    void Update() {
        transform.position = target.position + offset;
    }
}
