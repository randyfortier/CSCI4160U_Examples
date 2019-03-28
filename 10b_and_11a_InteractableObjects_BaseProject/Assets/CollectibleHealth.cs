using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : CollectibleItem {
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float healthGain = 20.0f;

    public override void Collect() {
        // health gain (up to maximum)
        playerHealth.health += healthGain;
        if (playerHealth.health > playerHealth.maxHealth) {
            playerHealth.health = playerHealth.maxHealth;
        }

        Debug.Log("Health kit used: " + playerHealth.health);
    }
}
