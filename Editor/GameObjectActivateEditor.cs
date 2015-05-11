using UnityEngine;
using System.Collections;
using UnityEditor;
using Rotorz.ReorderableList;

namespace GameObjectActivator {

	[CustomEditor(typeof(GameObjectActivate))]
	public class GameObjectActivateEditor : Editor {

		private SerializedProperty objsToEnable;

		private void OnEnable() {
			objsToEnable = serializedObject.FindProperty("objsToEnable");
		}

		public override void OnInspectorGUI() {
			serializedObject.Update();

			ReorderableListGUI.Title("Objects to enable");
			ReorderableListGUI.ListField(objsToEnable);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
