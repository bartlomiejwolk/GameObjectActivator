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
        #endregion
        #region UNITY MESSAGES

        private void OnEnable() {
            objectsToEnable = serializedObject.FindProperty("objectsToEnable");
            gameObjectsActivatedCallback =
                serializedObject.FindProperty("gameObjectsActivatedCallback");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            ReorderableListGUI.Title("Objects to enable");
            ReorderableListGUI.ListField(objectsToEnable);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(
                gameObjectsActivatedCallback,
                new GUIContent(
                    "Callback",
                    "Callback executed after all GOs were enabled."));

            serializedObject.ApplyModifiedProperties();
        }
        #endregion
    }
}
