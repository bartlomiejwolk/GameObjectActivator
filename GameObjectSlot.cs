// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the OnCollisionActivate extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;

// todo convert comments to xml

namespace OnCollisionActivateEx {

    /// Object to enable.
    [System.Serializable]
    public class GameObjectSlot {
        #region FIELDS

        /// Game object.
        [SerializeField]
        private GameObject objToEnable;

        [SerializeField]
        private string tag;

        /// <summary>
        /// Defines type of condition used to decide if specified game object
        /// should be enabled.
        /// </summary>
        [SerializeField]
        private InludeExcludeType includeExcludeType;

        /// Select to include or exclude a given tag.
        // todo rename to inclusionOption
        [SerializeField]
        private TagOptions tagOption;

        /// <summary>
        /// Only game object on selected layers will be taken into account.
        /// </summary>
        [SerializeField]
        private LayerMask layer;

        #endregion FIELDS

        #region PROPERTIES

        public string Tag {
            get { return tag; }
            set { tag = value; }
        }

        public GameObject ObjToEnable {
            get { return objToEnable; }
            set { objToEnable = value; }
        }

        public TagOptions TagOption {
            get { return tagOption; }
        }

        public InludeExcludeType IncludeExcludeType {
            get { return includeExcludeType; }
            set { includeExcludeType = value; }
        }

        public LayerMask Layer {
            get { return layer; }
            set { layer = value; }
        }

        #endregion PROPERTIES
    }

}