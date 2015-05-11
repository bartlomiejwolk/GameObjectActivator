using UnityEngine;
using UnityEditor;
using System.Collections;
using OneDayGame;

namespace GameObjectActivator {

    [CustomPropertyDrawer(typeof (ObjectToEnable))]
    public class ObjectToEnableDrawer : PropertyDrawer {

        private const float _rows = 2;

        public override float GetPropertyHeight(
            SerializedProperty property,
            GUIContent label) {
            return base.GetPropertyHeight(property, label)
                   * _rows // Each row is 16 px high.
                   + (_rows - 1) * 3; // Add 3 px for spece between rows.
        }

        public override void OnGUI(
            Rect pos,
            SerializedProperty prop,
            GUIContent label) {

            SerializedProperty objToEnable =
                prop.FindPropertyRelative("_objToEnable");
            SerializedProperty tagOption =
                prop.FindPropertyRelative("_tagOption");
            SerializedProperty tag =
                prop.FindPropertyRelative("_tag");

            // Draw objToEnable field.
            EditorGUIUtility.labelWidth = 85;
            EditorGUI.PropertyField(
                new Rect(pos.x, pos.y, pos.width, 16),
                objToEnable,
                new GUIContent("GameObject", "GameObject to enable."));

            // Draw tagOptions field.
            EditorGUI.PropertyField(
                new Rect(pos.x, pos.y + 19, pos.width * 0.3f, 16),
                tagOption,
                GUIContent.none);
            EditorGUIUtility.labelWidth = 40;
            EditorGUI.PropertyField(
                new Rect(
                    pos.x + pos.width * 0.01f + pos.width * 0.3f,
                    pos.y + 19,
                    pos.width * 0.69f,
                    16),
                tag,
                new GUIContent(
                    "Layer",
                    "Layer on which the hit object must be in order for this component to work."));
            EditorGUIUtility.labelWidth = 0;
        }

    }

}
