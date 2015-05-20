// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the GameObjectActivator extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace GameObjectActivatorEx {

    /// Enable child game object on collision with
    /// other game object.
    public class GameObjectActivator : MonoBehaviour {

        #region FIELDS
        [SerializeField]
        private List<ObjectToEnable> objectsToEnable = new List<ObjectToEnable>();

        [SerializeField]
        private UnityEvent gameObjectsEnabledCallback;

        #endregion

        #region PROPERTIES
        public List<ObjectToEnable> ObjectsToEnable {
            get { return objectsToEnable; }
            set { objectsToEnable = value; }
        }

        public UnityEvent GameObjectsEnabledCallback {
            get { return gameObjectsEnabledCallback; }
            set { gameObjectsEnabledCallback = value; }
        }
        #endregion

        #region METHODS
        /// Handle collision.
        // todo refactor
        public void OnCollisionEnable(RaycastHit hitInfo) {
            var hitGOTag = hitInfo.transform.gameObject.tag;

            foreach (ObjectToEnable obj in ObjectsToEnable) {
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
        #endregion
    }
}
