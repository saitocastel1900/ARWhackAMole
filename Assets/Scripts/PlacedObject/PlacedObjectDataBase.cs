using System.Collections.Generic;
using UnityEngine;

namespace PlacedObject
{
    [CreateAssetMenu(fileName = "PlacedObjectDataBase", menuName = "ScriptableObject/PlacedObjectDataBase")]
    public class PlacedObjectDataBase : ScriptableObject
    {
        /// <summary>
        /// 設置するオブジェクトデータの配列
        /// </summary>
        public List<PlacedObjectData> _placedObjectData;

        /// <summary>
        /// 設置するオブジェクトを取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlacedObjectData Get(string id)
        {
            foreach (var placedObject in _placedObjectData)
            {
                if (placedObject.Id == id)
                {
                    return placedObject;
                }
            }

            return null;
        }
    }
}