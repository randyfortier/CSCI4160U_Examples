using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMelee : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        CharacterDamage damage = other.gameObject.GetComponent<CharacterDamage>();

        if (damage != null) {
            damage.TakeDamage(15.0f);
        }
    }
}
