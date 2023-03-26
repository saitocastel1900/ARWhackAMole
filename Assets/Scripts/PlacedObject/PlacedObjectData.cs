using System;
using UnityEngine;

namespace PlacedObject
{
    [Serializable]
    public class PlacedObjectData
    {
        /// <summary>
        /// オブジェクト
        /// </summary>
        public GameObject Item;

        /// <summary>
        /// Id
        /// </summary>
        public string Id;

        /// <summary>
        /// 説明
        /// </summary>
        public string ExplainText;
    }
}