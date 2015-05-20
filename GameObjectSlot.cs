// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the GameObjectActivator extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;

// todo convert comments to xml
namespace GameObjectActivatorEx {

    /// Object to enable.
    [System.Serializable]
    public class GameObjectSlot {

        #region FIELDS
        /// Select to include or exclude a given tag.
        [SerializeField]
        private TagOptions _tagOption;

        /// On collision with objects with this tag
        /// the object won't be enabled.
        [SerializeField]
        private string _tag;

        /// Game object.
        [SerializeField]
        private GameObject _objToEnable;
        #endregion
        #region PROPERTIES
        public string ExcludeTag {
            get { return _tag; }
            set { _tag = value; }
        }

        public GameObject ObjToEnable {
            get { return _objToEnable; }
            set { _objToEnable = value; }
        }
        public TagOptions TagOption {
            get { return _tagOption; }
        }
        #endregion
    }

}