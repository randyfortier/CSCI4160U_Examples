using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGrayscaleEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    private float effectAmount = 0.0f;

    [SerializeField]
    private bool autoFade = true;

    [SerializeField]
    private float fadeSpeed = 0.05f;

    [SerializeField]
    private Shader shader = null;

    private Material material = null;

    void Update()
    {
        if (autoFade) {
            effectAmount -= fadeSpeed * Time.deltaTime;
            effectAmount = Mathf.Max(effectAmount, 0.0f);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (shader == null)
            return;

        if (material == null) {
            material = new Material(shader);
        }

        // send data into shader
        material.SetFloat("_EffectAmount", effectAmount);

        // copy the pixels onto the destination image/texture
        Graphics.Blit(source, destination, material);
    }
}
