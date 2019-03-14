using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] private Transform camera = null;

    [SerializeField] private ParticleSystem wallImpactEffect = null;
    [SerializeField] private ParticleSystem bloodImpactEffect = null;

    private float range = 100f;

    void Update() {
        if (Input.GetButtonDown("Shoot")) {
            RaycastHit hit;

            LayerMask enemyMask = LayerMask.GetMask("Enemies");
            LayerMask wallsMask = LayerMask.GetMask("PlayArea");

            if (Physics.Raycast(camera.position, camera.forward, out hit, range, enemyMask)) {
                Debug.Log("Shot enemy: " + hit.collider.name + " at " + hit.point);

                ParticleSystem blood = Instantiate(bloodImpactEffect, hit.point, Quaternion.identity);
            } else if (Physics.Raycast(camera.position, camera.forward, out hit, range, wallsMask)) {
                Debug.Log("Shot the wall: " + hit.collider.name);

                ParticleSystem spark = Instantiate(wallImpactEffect, hit.point, Quaternion.identity);
            }
        }
    }
}
