using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor {
    [DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
    static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType) {
        // draw starting point
        var offsetPosition = launcher.transform.TransformPoint(launcher.offset);
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");

        if (launcher.projectile != null) {
            // generate a list of positions along the trajectory
            var velocity = launcher.transform.forward * launcher.velocity / launcher.projectile.mass;
            var position = offsetPosition;
            var positions = new List<Vector3>();
            var physicsStep = 0.1f;
            for (var i = 0f; i <= 1f; i += physicsStep) {
                positions.Add(position);
                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }

            // draw a line along the trajectory
            using (new Handles.DrawingScope(Color.yellow)) {
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[positions.Count - 1], 0.125f);
                Handles.Label(positions[positions.Count - 1], "Estimated Position (1 sec)");
            }
        }
    }

    void OnSceneGUI() {
        var launcher = target as Launcher;
        var transform = launcher.transform;

        using (var cc = new EditorGUI.ChangeCheckScope()) {
            // determine the desired position
            var newOffset = transform.InverseTransformPoint(
                Handles.PositionHandle(transform.TransformPoint(launcher.offset), transform.rotation)
            );

            // record offset move for undo purposes
            if (cc.changed) {
                Undo.RecordObject(launcher, "Offset Change");
                launcher.offset = newOffset;
            }
        }

        Handles.BeginGUI();
        var rectMin = Camera.current.WorldToScreenPoint(launcher.transform.position + launcher.offset);
        var rect = new Rect();
        rect.xMin = rectMin.x;
        rect.yMin = SceneView.currentDrawingSceneView.position.height - rectMin.y;
        rect.width = 64;
        rect.height = 18;
        GUILayout.BeginArea(rect);
        using (new EditorGUI.DisabledGroupScope(!Application.isPlaying)) {
            if (GUILayout.Button("Fire")) {
                launcher.Fire();
            }
        }
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}