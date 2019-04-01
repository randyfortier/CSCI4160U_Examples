using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotator : MonoBehaviour {
    [SerializeField] float rotateSpeed = 2.0f;

    private float rotation = 0.1f;

    void Update() {
        transform.Rotate(new Vector3(0.0f, rotation * rotateSpeed, 0.0f));
    }
}
