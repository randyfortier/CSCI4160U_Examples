using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : InteractableObject {
    public virtual void Collect() {
        Debug.Log("Item collected: " + gameObject.name);
    }

    private void Complete() {
        gameObject.SetActive(false);
    }

    public override void Activate() {
        Debug.Log("collecting item: " + gameObject.name);
        Collect();
        Complete();
    }
}
