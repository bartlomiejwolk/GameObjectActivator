// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the GameObjectActivator extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;
using UnityEditor;
using Rotorz.ReorderableList;

namespace GameObjectActivatorEx {

    [CustomEditor(typeof(GameObjectActivator))]
    public class GameObjectActivatorEditor : Editor {

        #region SERIALIZED PROPERTIES
        private SerializedProperty objectsToEnable;
        private SerializedProperty gameObjectsActivatedCallback;
        private SerializedProperty description;
        #endregion
        #region UNITY MESSAGES

        private void OnEnable() {
            objectsToEnable = serializedObject.FindProperty("objectsToEnable");
            gameObjectsActivatedCallback =
                serializedObject.FindProperty("gameObjectsActivatedCallback");
            description = serializedObject.FindProperty("description");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();
            
            DrawObjectsToEnableList();

            EditorGUILayout.Space();

            DrawGameObjectsActivatedCallback();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawGameObjectsActivatedCallback() {
            EditorGUILayout.PropertyField(
                gameObjectsActivatedCallback,
                new GUIContent(
                    "Callback",
                    "Callback executed after all GOs were enabled."));
        }

        private void DrawObjectsToEnableList() {
            ReorderableListGUI.Title("Objects to enable");
            ReorderableListGUI.ListField(objectsToEnable);
        }

        #endregion
        #region INSPECTOR CONTROLS

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    GameObjectActivator.Version,
                    GameObjectActivator.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/GameObjectActivator")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(
                    typeof(GameObjectActivator));
            }
        }

        #endregion METHODS
    }
}
