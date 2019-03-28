using UnityEngine;

public class InteractableDrawer : InteractableObject {
    [SerializeField] string animatorParam;

    private Animator animator = null;
    private bool isOpen;

    private void Awake() {
        animator = GetComponentInParent<Animator>();
    }

    public override void Activate() {
        OpenDrawer();
    }

    private void OpenDrawer() {
        isOpen = !isOpen;
        animator.SetBool(animatorParam, isOpen);
    }
}
