using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(Projectile))]
[CanEditMultipleObjects] // allow multi-select
public class ProjectileEditor : Editor {
    private SerializedProperty damageRadiusProperty;

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmosSelected(Projectile projectile, GizmoType gizmoType) {
        Gizmos.DrawSphere(projectile.transform.position, 0.125f);
    }

    private void OnEnable() {
        damageRadiusProperty = serializedObject.FindProperty("damageRadius");
    }

    public override void OnInspectorGUI() {
        // draws the UI in the inspector properties panel

        serializedObject.Update();

        // show the custom GUI controls
        EditorGUILayout.IntSlider(damageRadiusProperty, 0, 25, new GUIContent("Damage Radius"));

        // Only show the damage progress bar if all the objects have the same damage value:
        if (!damageRadiusProperty.hasMultipleDifferentValues) {
            // draw damage radius progress bar
            Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rect, damageRadiusProperty.intValue / 25.0f, "Damage Radius");
            EditorGUILayout.Space();
        } else {
            Debug.Log("damageRadiusProperty.hasMultipleDifferentValues is true");
        }
        serializedObject.ApplyModifiedProperties();
    }

    void OnSceneGUI() {
        // draws the UI in the scene panel

        // draw a sphere with at the projectile's position with radius equal to the damage radius
        var projectile = (Projectile)target;
        var transform = projectile.transform;
        projectile.damageRadius = (int)Handles.RadiusHandle(transform.rotation, transform.position, (int)projectile.damageRadius);
    }
}
