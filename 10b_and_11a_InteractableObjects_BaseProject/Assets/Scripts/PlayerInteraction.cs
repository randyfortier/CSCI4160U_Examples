using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour { 
    [SerializeField] private Transform camera;
    [SerializeField] private float range = 5f;
    [SerializeField] private Text interactionText;

    void Awake() {        
    }

    void Update() {
        RaycastHit hit;
        InteractableObject interactableObject = null;

        LayerMask interactableMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(camera.position, camera.forward, out hit, range, interactableMask)) {
            interactableObject = hit.collider.gameObject.GetComponent<InteractableObject>();

            if (interactableObject != null) {
                interactionText.text = interactableObject.GetInteractionText();
            } else {
                interactionText.text = "";
            }
        } else {
            interactionText.text = "";
        }

        if (Input.GetButtonDown("Fire2") && interactableObject != null) {
            interactableObject.Activate();
        }
    }


}
