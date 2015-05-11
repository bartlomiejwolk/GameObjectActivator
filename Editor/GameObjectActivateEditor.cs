using UnityEngine;
using System.Collections;
using UnityEditor;
using Rotorz.ReorderableList;

namespace OneDayGame {

	[CustomEditor(typeof(GameObjectActivate))]
	public class GameObjectActivateEditor : Editor {

		private SerializedProperty _collisionComponent;
		/*private SerializedProperty _tagOption;
		private SerializedProperty _tag;*/
		private SerializedProperty _objsToEnable;

		private void OnEnable() {
			_collisionComponent = serializedObject.FindProperty("_collisionComponent");
			/*_tagOption = serializedObject.FindProperty("_tagOption");
			_tag = serializedObject.FindProperty("_tag");*/
			_objsToEnable = serializedObject.FindProperty("_objsToEnable");
		}

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();
			GameObjectActivate script = (GameObjectActivate)target;
			serializedObject.Update();

			EditorGUILayout.PropertyField(_collisionComponent);

			/*script.ObjToEnable = (GameObject)EditorGUILayout.ObjectField(
					"Obj. to enable",
					script.ObjToEnable,
					typeof(GameObject),
					true);
			//script.ExcludeTag = EditorGUILayout.TextField("Exclude tag", script.ExcludeTag);
			EditorGUILayout.BeginHorizontal();
			EditorGUIUtility.labelWidth = 70;
			EditorGUILayout.PropertyField(_tagOption);
			EditorGUIUtility.labelWidth = 40;
			EditorGUILayout.PropertyField(_tag);
			EditorGUILayout.EndHorizontal();*/

			ReorderableListGUI.Title("Objects to enable");
			ReorderableListGUI.ListField(_objsToEnable);

			// Save changes
			if (GUI.changed) {
				EditorUtility.SetDirty(script);
			}
			serializedObject.ApplyModifiedProperties();
		}
	}
}
