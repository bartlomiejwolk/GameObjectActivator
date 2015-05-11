using UnityEngine;
using System.Collections;
using UnityEditor;
using Rotorz.ReorderableList;

namespace OneDayGame {

	[CustomEditor(typeof(GameObjectActivate))]
	public class GameObjectActivateEditor : Editor {

		private SerializedProperty _objsToEnable;

		private void OnEnable() {
			_objsToEnable = serializedObject.FindProperty("_objsToEnable");
		}

		public override void OnInspectorGUI() {
			serializedObject.Update();

			ReorderableListGUI.Title("Objects to enable");
			ReorderableListGUI.ListField(_objsToEnable);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
