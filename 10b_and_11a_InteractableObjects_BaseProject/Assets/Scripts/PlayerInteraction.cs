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
        CollectibleItem collectibleItem = null;

        LayerMask collectibleMask = LayerMask.GetMask("Collectible");
        if (Physics.Raycast(camera.position, camera.forward, out hit, range, collectibleMask)) {
            collectibleItem = hit.collider.gameObject.GetComponent<CollectibleItem>();

            if (collectibleItem != null) {
                interactionText.text = collectibleItem.GetInteractionText();
            } else {
                interactionText.text = "";
            }
        } else {
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
        }

        if (Input.GetButtonDown("Fire2") && collectibleItem != null) {
            Debug.Log("collectible item: " + collectibleItem);
            collectibleItem.Activate();
        } else if (Input.GetButtonDown("Fire2") && interactableObject != null) {
            interactableObject.Activate();
        }
    }


}
