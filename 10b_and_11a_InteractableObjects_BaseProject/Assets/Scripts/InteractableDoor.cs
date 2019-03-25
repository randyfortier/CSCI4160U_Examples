using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : InteractableObject {
    [SerializeField] private bool autoOpen = true;
    [SerializeField] private bool autoClose = true;
    [SerializeField] private float autoCloseDelay = 8.0f;

    [SerializeField] private AudioClip doorOpenAudioClip;
    [SerializeField] private AudioClip doorCloseAudioClip;
    [SerializeField] private float doorOpenAudioDelay = 0.0f;
    [SerializeField] private float doorCloseAudioDelay = 2.0f;

    [SerializeField] private bool isUnlocked = true;
    [SerializeField] private string lockedText = "Find a key to open this door";

    private Animator animator = null;
    private AudioSource audioSource = null;

    private bool isOpen = false;

    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (autoOpen && !isOpen) {
            if (other.gameObject.CompareTag("Player")) {
                OpenDoor();
            }
        }
    }

    private void OpenDoor() {
        isOpen = true;
        animator.SetBool("Open", true);

        // play the sound effect
        audioSource.clip = doorOpenAudioClip;
        audioSource.PlayDelayed(doorOpenAudioDelay);

        // auto-close
        if (autoClose) {
            //Invoke("CloseDoor", autoCloseDelay);
            StartCoroutine(CloseAfterDelay(autoCloseDelay));
        }
    }

    private void CloseDoor() {
        isOpen = false;
        animator.SetBool("Open", false);

        // play the sound effect
        audioSource.clip = doorCloseAudioClip;
        audioSource.PlayDelayed(doorCloseAudioDelay);
    }

    public override void Activate() {
        if (!isOpen && isUnlocked) {
            OpenDoor();
        }
    }

    public override string GetInteractionText() {
        if (isUnlocked) {
            return activateText;
        } else {
            return lockedText;
        }
    }

    public IEnumerator CloseAfterDelay(float delay) {
        float timePassed = 0.0f;

        // wait until the delay has passed
        do {
            timePassed += Time.deltaTime;
            yield return null;
        } while (timePassed <= delay);

        CloseDoor();

        yield return null;
    }

}
