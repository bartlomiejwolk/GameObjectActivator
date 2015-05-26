﻿// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
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
            var hitGOTag = hitInfo.transform.gameObject.tag;
            var hitGoLayer = hitInfo.transform.gameObject.layer;

            foreach (var obj in ObjectsToEnable) {
                switch (obj.TagOption) {
                    case TagOptions.Include:
                        if (hitGOTag != obj.Tag) {
                            break;
                        }
                        obj.ObjToEnable.SetActive(true);
                        break;

                    case TagOptions.Exclude:
                        // Don't enable target object when hit a GO with
                        // excluded tag.
                        if (hitGOTag == obj.Tag) {
                            break;
                        }
                        obj.ObjToEnable.SetActive(true);
                        break;
                }
            }

            GameObjectsActivatedCallback.Invoke();
        }

        #endregion METHODS
    }

}