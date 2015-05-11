using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OneDayGame {

	/// Enable child game object on collision with
	/// other game object.
	public class GameObjectActivate : OnCollision {

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

		public override void Start () {
			base.Start();
		}

		public override void Update () {
			base.Update();
		}

		public override void FixedUpdate() {
			base.FixedUpdate();
			// Check for collision
			_collision = CollisionComponent.Collision;
			if (_collision) {
				HandleCollision();
			}
		}

		/// Handle collision.
		private void HandleCollision() {
			foreach (ObjectToEnable obj in _objsToEnable) {
				switch (obj.TagOption) {
					case TagOptions.Include:
						if (CollisionComponent.HitObject.tag != obj.ExcludeTag) {
							break;
						}
						obj.ObjToEnable.SetActive(true);
						break;
					case TagOptions.Exclude:
						// Don't enable target object when hit a GO
						// with excluded tag.
						if (CollisionComponent.HitObject.tag == obj.ExcludeTag) {
							break;
						}
						obj.ObjToEnable.SetActive(true);
						break;
				}
			}
		}
	}
}
