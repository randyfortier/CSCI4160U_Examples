using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform target;

    void Update() {
        Vector3 newCameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = newCameraPosition;
    }
}
