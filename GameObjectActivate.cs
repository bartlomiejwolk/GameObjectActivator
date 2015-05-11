using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameObjectActivator {

    /// Enable child game object on collision with
    /// other game object.
    public class GameObjectActivate : MonoBehaviour {

        private List<ObjectToEnable> objsToEnable = new List<ObjectToEnable>();

        public List<ObjectToEnable> ObjsToEnable {
            get { return objsToEnable; }
            set { objsToEnable = value; }
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
        }
    }
}
