using System;
using Const;
using UnityEngine;
using UniRx;

namespace PlacedObject
{
    public class PlacedObjectManager : MonoBehaviour , IPlacedObjectManager
    {
        /// <summary>
        /// オブジェクトが生成されたかどうか
        /// </summary>
        public IReactiveProperty<bool> CreatedObjectPrp => _createdObjectPrp;

        private BoolReactiveProperty _createdObjectPrp = new BoolReactiveProperty(false);

        /// <summary>
        /// 設置するオブジェクトのリスト
        /// </summary>
        [SerializeField] private PlacedObjectDataBase _placedObjectData;

        /// <summary>
        /// 設置するオブジェクトのキャッシュ
        /// </summary>
        private GameObject _placedObject;

        /// <summary>
        /// /オブジェクトを生成する
        /// </summary>
        /// <param name="position">オブジェクトの設置場所</param>
        /// <param name="rotation">オブジェクトの角度</param>
        public void PlacedObjectCreate(Vector3 position, Quaternion rotation)
        {
            var data = _placedObjectData.Get(InGameConst.PlacedObjectId);

            if (data != null)
            {
                _placedObject = Instantiate(data.Item, position, rotation) as GameObject;
                _createdObjectPrp.Value = true;
            }
        }

        /// <summary>
        /// 設置したオブジェクトを破壊
        /// </summary>
        public void PlacedObjectDestroy()
        {
            Destroy(_placedObject);
            _createdObjectPrp.Value = false;
        }

        /// <summary>
        /// 設置したオブジェクトを破壊する
        /// </summary>
        /// <returns></returns>
        public GameObject GetPlacedObject()
        {
            return _placedObject;
        }
    }
}