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
        private List<GameObjectSlot> objectsToEnable = new List<GameObjectSlot>();

        /// <summary>
        /// Callback executed after all GOs were handled.
        /// </summary>
        [SerializeField]
        private UnityEvent gameObjectsActivatedCallback;

        #endregion

        #region PROPERTIES
        public List<GameObjectSlot> ObjectsToEnable {
            get { return objectsToEnable; }
            set { objectsToEnable = value; }
        }

        public UnityEvent GameObjectsActivatedCallback {
            get { return gameObjectsActivatedCallback; }
            set { gameObjectsActivatedCallback = value; }
        }
        #endregion

        #region METHODS
        /// Handle collision.
        public void Activate(RaycastHit hitInfo) {
            var hitGOTag = hitInfo.transform.gameObject.tag;

            foreach (GameObjectSlot obj in ObjectsToEnable) {
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

            GameObjectsActivatedCallback.Invoke();
        }
        #endregion
    }
}
