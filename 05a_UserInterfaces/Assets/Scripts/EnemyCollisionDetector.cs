using UnityEngine;
using UnityEngine.UI;

public class EnemyCollisionDetector : MonoBehaviour {
    public Slider playerHealthSlider;

    private CharacterController2D controller;

    private float timeSinceLastTurn;
    private float turnDuration = 2f;
    private float velocityX = 2f;

    private void Start() {
        timeSinceLastTurn = Time.time;
        controller = GetComponent<CharacterController2D>();
    }

    private void Update() {
        if ((Time.time - timeSinceLastTurn) > turnDuration) {
            // turn
            velocityX *= -1f;

            // reset timer
            timeSinceLastTurn = Time.time;
        }

        controller.Move(velocityX * Time.deltaTime, false, false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerHealthSlider.value -= 10;
            Debug.Log("Ouch!");
        }

    }
}
