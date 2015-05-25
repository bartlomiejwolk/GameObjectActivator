// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the OnCollisionActivate extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace OnCollisionActivateEx {

    [CustomPropertyDrawer(typeof (GameObjectSlot))]
    public class ObjectToEnableDrawer : PropertyDrawer {

        private const float Rows = 2;

        public override float GetPropertyHeight(
            SerializedProperty property,
            GUIContent label) {
            return base.GetPropertyHeight(property, label)
                   * Rows // Each row is 16 px high.
                   + (Rows - 1) * 3; // Add 3 px for spece between rows.
        }

        public override void OnGUI(
            Rect pos,
            SerializedProperty prop,
            GUIContent label) {

            var objToEnable =
                prop.FindPropertyRelative("objToEnable");
            var tagOption =
                prop.FindPropertyRelative("tagOption");
            var tag =
                prop.FindPropertyRelative("tag");
            var includeExcludeType =
                prop.FindPropertyRelative("includeExcludeType");

            DrawObjToEnableField(pos, objToEnable);

            DrawInclusionOptionDropdown(pos, tagOption);
            DrawIncludeExcludeTypeDropdown(pos, includeExcludeType);
            DrawTagDropdown(pos, tag);
        }

        private void DrawIncludeExcludeTypeDropdown(
            Rect pos,
            SerializedProperty includeExcludeType) {

        }

        private static void DrawObjToEnableField(
            Rect pos,
            SerializedProperty objToEnable) {

            // Draw objToEnable field.
            EditorGUIUtility.labelWidth = 85;

            EditorGUI.PropertyField(
                new Rect(pos.x, pos.y, pos.width, 16),
                objToEnable,
                new GUIContent("GameObject", "GameObject to enable."));
        }

        private static void DrawInclusionOptionDropdown(
            Rect pos,
            SerializedProperty tagOption) {

            EditorGUI.PropertyField(
                new Rect(pos.x, pos.y + 19, pos.width * 0.3f, 16),
                tagOption,
                GUIContent.none);
        }

        // todo draw dropdown
        private static void DrawTagDropdown(Rect pos, SerializedProperty tag) {
            EditorGUIUtility.labelWidth = 40;

            EditorGUI.PropertyField(
                new Rect(
                    pos.x + pos.width * 0.01f + pos.width * 0.3f,
                    pos.y + 19,
                    pos.width * 0.69f,
                    16),
                tag,
                new GUIContent(
                    "",
                    "Target GO must have this tag attached in order to be " +
                    "enabled."));

            EditorGUIUtility.labelWidth = 0;
        }

    }

}