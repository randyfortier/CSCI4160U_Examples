using UnityEngine;

public class CollectibleWeapon : CollectibleItem {
    [SerializeField] PlayerWeapon playerWeapon;
    [SerializeField] int ammoGain = 12;
    [SerializeField] bool includesWeapon = false;

    public override void Collect() {
        playerWeapon.ammo += ammoGain;

        if (includesWeapon) {
            playerWeapon.exists = true;
        }
    }
}
