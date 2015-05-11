using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OneDayGame {

	/// Enable child game object on collision with
	/// other game object.
	public class GameObjectActivate : MonoBehaviour {

		public enum TagOptions { Include, Exclude }

		/// Object to enable.
		[System.Serializable]
		public class ObjectToEnable {

			/// Game object.
			[SerializeField]
			private GameObject _objToEnable;
			public GameObject ObjToEnable {
				get { return _objToEnable; }
				set { _objToEnable = value; }
			}

			/// Select to include or exclude a given tag.
			[SerializeField]
			private TagOptions _tagOption;
			public TagOptions TagOption {
				get { return _tagOption; }
			}

			/// On collision with objects with this tag
			/// the object won't be enabled.
			[SerializeField]
			private string _tag;
			public string ExcludeTag {
				get { return _tag; }
				set { _tag = value; }
			}
		}

		public List<ObjectToEnable> _objsToEnable = new List<ObjectToEnable>();

		private void FixedUpdate() {
		}

		/// Handle collision.
		public void OnCollisionEnable(RaycastHit hitInfo) {
		    var hitGOTag = hitInfo.transform.gameObject.tag;

			foreach (ObjectToEnable obj in _objsToEnable) {
				switch (obj.TagOption) {
					case TagOptions.Include:
						if (tag != obj.ExcludeTag) {
							break;
						}
						obj.ObjToEnable.SetActive(true);
						break;
					case TagOptions.Exclude:
						// Don't enable target object when hit a GO
						// with excluded tag.
						if (tag == obj.ExcludeTag) {
							break;
						}
						obj.ObjToEnable.SetActive(true);
						break;
				}
			}
		}
	}
}
