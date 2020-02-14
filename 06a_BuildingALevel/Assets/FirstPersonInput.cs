﻿using UnityEngine;

public class FirstPersonInput : MonoBehaviour {
    [SerializeField] private Transform camera = null;
    [SerializeField] private Animator gunAnimator = null;
    [SerializeField] private GameObject bulletHolePrefab = null;

    float range = 100f;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        RaycastHit hit;

        LayerMask enemyMask = LayerMask.GetMask("Enemies");
        LayerMask groundMask = LayerMask.GetMask("Ground");

        gunAnimator.SetTrigger("Fire");

        if (Physics.Raycast(camera.position, camera.forward, out hit, range, enemyMask)) {
            Debug.Log("Shot an enemy thing:" + hit.collider.name);

            Health enemyHealth = hit.collider.GetComponent<Health>();
            enemyHealth.TakeDamage(10);
            if (enemyHealth.isDead) {
                hit.collider.gameObject.SetActive(false);
            }
        } else if (Physics.Raycast(camera.position, camera.forward, out hit, range, groundMask)) {
            Debug.Log("Shot a wall thing:" + hit.collider.name);

            Instantiate(bulletHolePrefab, 
                hit.point + (0.01f * hit.normal), 
                Quaternion.LookRotation(-1 * hit.normal, hit.transform.up));
        }
    }
}
