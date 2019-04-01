using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class CameraBloodEffect : MonoBehaviour {
    [SerializeField]
    private Texture2D bloodTexture = null;

    [SerializeField]
    private Texture2D bloodNormalMap = null;

    [SerializeField]
    [Range(0, 1)]
    private float bloodAmount = 0.0f;

    [SerializeField]
    [Range(0, 1)]
    private float minBloodAmount = 0.0f;

    [SerializeField]
    private float distortion = 1.0f;

    [SerializeField]
    private bool autoFade = true;

    [SerializeField]
    private float fadeSpeed = 0.05f;

    [SerializeField]
    private Shader shader = null;

    private Material material = null;

    void Update() {
        if (autoFade) {
            bloodAmount -= fadeSpeed * Time.deltaTime;
            bloodAmount = Mathf.Max(bloodAmount, minBloodAmount);
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        if (shader == null) return;
        if (material == null) {
            material = new Material(shader);
        }

        if (bloodTexture != null)
            material.SetTexture("_BloodTex", bloodTexture);

        if (bloodNormalMap != null)
            material.SetTexture("_BloodBump", bloodNormalMap);

        material.SetFloat("_Distortion", distortion);
        material.SetFloat("_BloodAmount", bloodAmount);

        // copy the grayscale pixels over the resulting image
        Graphics.Blit(src, dest, material);
    }
}
