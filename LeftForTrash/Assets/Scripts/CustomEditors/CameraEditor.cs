using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(CameraController))]
public class CameraEditor : Editor {

    override public void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Space();
        CameraController controller = target as CameraController;

        controller.lerp_movement = EditorGUILayout.Toggle("Lerp Movement", controller.lerp_movement);

        if(controller.lerp_movement)
        {
            controller.position_speed = EditorGUILayout.FloatField("Position Lerp Rate",controller.position_speed);
            controller.size_speed = EditorGUILayout.FloatField("Size Lerp Rate", controller.size_speed);
            controller.min_size = EditorGUILayout.FloatField("Min Camera Size", controller.min_size);
            controller.max_size = EditorGUILayout.FloatField("Max Camera Size", controller.max_size);
        }
    }


}
