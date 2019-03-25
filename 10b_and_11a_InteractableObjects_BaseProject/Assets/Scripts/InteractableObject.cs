using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [SerializeField] protected string activateText = "Right-click to interact";

    public virtual string GetInteractionText() {
        return activateText;
    }

    public virtual void Activate() {
        Debug.Log("Activate():: " + gameObject.name);
    }
}
