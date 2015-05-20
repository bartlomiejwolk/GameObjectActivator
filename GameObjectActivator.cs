using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace GameObjectActivatorEx {

    /// Enable child game object on collision with
    /// other game object.
    public class GameObjectActivator : MonoBehaviour {

        [SerializeField]
        private List<ObjectToEnable> objsToEnable = new List<ObjectToEnable>();

        [SerializeField]
        private UnityEvent gameObjectsEnabledCallback;

        public List<ObjectToEnable> ObjsToEnable {
            get { return objsToEnable; }
            set { objsToEnable = value; }
        }

        public UnityEvent GameObjectsEnabledCallback {
            get { return gameObjectsEnabledCallback; }
            set { gameObjectsEnabledCallback = value; }
        }

        /// Handle collision.
        // todo refactor
        public void OnCollisionEnable(RaycastHit hitInfo) {
            var hitGOTag = hitInfo.transform.gameObject.tag;

            foreach (ObjectToEnable obj in ObjsToEnable) {
                switch (obj.TagOption) {
                    case TagOptions.Include:
                        if (hitGOTag != obj.ExcludeTag) {
                            break;
                        }
                        obj.ObjToEnable.SetActive(true);
                        break;
                    case TagOptions.Exclude:
                        // Don't enable target object when hit a GO
                        // with excluded tag.
                        if (hitGOTag == obj.ExcludeTag) {
                            break;
                        }
                        obj.ObjToEnable.SetActive(true);
                        break;
                }
            }

            GameObjectsEnabledCallback.Invoke();
        }
    }
}
