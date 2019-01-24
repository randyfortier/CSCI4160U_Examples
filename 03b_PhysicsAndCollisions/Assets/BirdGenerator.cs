using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour {
    [Header("Generation Region")]
    public float minimumX = -5f;
    public float maximumX = 5f;
    public float minimumY = -5f;
    public float maximumY = 5f;

    [Header("Generation Params")]
    public GameObject birdPrefab;
    public int numBirdsToGenerate;

    [ContextMenu("Generate")]
    void GenerateBirds() {
        for (int i = 0; i < numBirdsToGenerate; i++) {
            // generate a position
            float x = Random.Range(minimumX, maximumX);
            float y = Random.Range(minimumY, maximumY);
            Vector3 position = new Vector3(x, y, 0.0f);
            Quaternion rotation = Quaternion.identity;

            // generate a bird
            GameObject newBird = Instantiate(birdPrefab, position, rotation);
            newBird.transform.SetParent(transform);
        }
    }

    [ContextMenu("Kill All")]
    void KillAllBirds() {
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++) {
            if (children[i].gameObject != transform.gameObject) {
                DestroyImmediate(children[i].gameObject);
            }
        }
    }
}
