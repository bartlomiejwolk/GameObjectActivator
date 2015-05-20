using UnityEngine;
using System.Collections;
using UnityEditor;
using Rotorz.ReorderableList;

namespace GameObjectActivatorEx {

    [CustomEditor(typeof(GameObjectActivate))]
    public class GameObjectActivateEditor : Editor {

        private SerializedProperty objsToEnable;
        private SerializedProperty gameObjectsEnabledCallback;

        private void OnEnable() {
            objsToEnable = serializedObject.FindProperty("objsToEnable");
            gameObjectsEnabledCallback =
                serializedObject.FindProperty("gameObjectsEnabledCallback");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            ReorderableListGUI.Title("Objects to enable");
            ReorderableListGUI.ListField(objsToEnable);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(
                gameObjectsEnabledCallback,
                new GUIContent(
                    "Callback",
                    "Callback executed after all GOs were enabled."));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
