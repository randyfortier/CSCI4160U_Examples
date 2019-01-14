using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SampleScript))]
public class SampleEditor : Editor {
    void OnSceneGUI() {
        SampleScript script = target as SampleScript;

        script.offset = script.transform.InverseTransformPoint(
            Handles.PositionHandle(script.transform.TransformPoint(script.offset),
                                   script.transform.rotation));
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmosSelected(SampleScript script, GizmoType gizmoType) {
        Gizmos.DrawSphere(script.transform.position, 0.2f);
    }
}
