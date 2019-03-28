using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKeypad : InteractableObject {
    [SerializeField] private float audioDelay = 0.0f;
    [SerializeField] private InteractableDoor doorToUnlock = null;

    private AudioSource audioSource = null;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Activate() {
        Unlock();
    }

    private void Unlock() {
        doorToUnlock.Unlock();

        // play the sound effect
        audioSource.Play((ulong)(audioDelay * 1000));
    }
}
