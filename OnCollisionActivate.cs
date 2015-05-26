// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the OnCollisionActivate extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OnCollisionActivateEx {

    // todo extract
    /// <summary>
    /// What should be subject to inclusion/exclusion.
    /// </summary>
    public enum InludeExcludeType { Tag, Layer }

    /// Enable child game object on collision with other game object.
    public class OnCollisionActivate : MonoBehaviour {
        #region CONSTANTS

        public const string Extension = "OnCollisionActivate";
        public const string Version = "v0.1.0";

        #endregion CONSTANTS

        #region FIELDS

        [SerializeField]
        private string description = "Description";

        // todo move comments to properties
        /// <summary>
        ///     Callback executed after all game objects are handled.
        /// </summary>
        [SerializeField]
        private UnityEvent gameObjectsActivatedCallback;

        /// <summary>
        /// List of game objects that may be enabled.
        /// </summary>
        [SerializeField]
        private List<GameObjectSlot> objectsToEnable =
            new List<GameObjectSlot>();

        #endregion FIELDS

        #region PROPERTIES

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public UnityEvent GameObjectsActivatedCallback {
            get { return gameObjectsActivatedCallback; }
            set { gameObjectsActivatedCallback = value; }
        }

        public List<GameObjectSlot> ObjectsToEnable {
            get { return objectsToEnable; }
            set { objectsToEnable = value; }
        }

        #endregion PROPERTIES

        #region METHODS

        // todo add doc
        public void Activate(RaycastHit hitInfo) {

            foreach (var objectSlot in ObjectsToEnable) {
                HandleActivateGameObject(objectSlot, hitInfo);
            }

            GameObjectsActivatedCallback.Invoke();
        }

        private void HandleActivateGameObject(
            GameObjectSlot gameObjectSlot,
            RaycastHit hitInfo) {

            HandleActivateByTag(gameObjectSlot, hitInfo);
            HandleActivateByLayer(gameObjectSlot, hitInfo);
        }

        private void HandleActivateByLayer(
            GameObjectSlot gameObjectSlot,
            RaycastHit hitInfo) {

            if (gameObjectSlot.IncludeExcludeType != InludeExcludeType.Layer) {
                return;
            }

            var hitGoLayer = hitInfo.transform.gameObject.layer;

            // Handle include/exclude option.
            switch (gameObjectSlot.TagOption) {
                case TagOptions.Include:
                    // Check layer.
                    if (hitGoLayer == gameObjectSlot.Layer) {
                        gameObjectSlot.ObjToEnable.SetActive(true);
                    } 
                    break;
                case TagOptions.Exclude:
                    if (hitGoLayer != gameObjectSlot.Layer) {
                        gameObjectSlot.ObjToEnable.SetActive(true);
                    } 
                    break;
            }
        }

        private void HandleActivateByTag(
            GameObjectSlot gameObjectSlot,
            RaycastHit hitInfo) {

            if (gameObjectSlot.IncludeExcludeType != InludeExcludeType.Tag) {
                return;
            }

            var hitGOTag = hitInfo.transform.gameObject.tag;

            // Handle include/exclude option.
            switch (gameObjectSlot.TagOption) {
                case TagOptions.Include:
                    // Check tag.
                    if (hitGOTag == gameObjectSlot.Tag) {
                        gameObjectSlot.ObjToEnable.SetActive(true);
                    }
                    break;
                case TagOptions.Exclude:
                    if (hitGOTag != gameObjectSlot.Tag) {
                        gameObjectSlot.ObjToEnable.SetActive(true);
                    }
                    break;
            }
        }

        #endregion METHODS
    }

}