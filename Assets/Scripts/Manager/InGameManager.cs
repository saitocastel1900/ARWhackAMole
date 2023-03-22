using System;
using UnityEngine;
using Manager.ARSystemManager;
using UI;

namespace Manager
{
    public class InGameManager : MonoBehaviour
    {
        /// <summary>
        /// 設置するオブジェクトの生成時のコールバック
        /// </summary>
        public event Action OnCreatedObjectCallBack;
        
        /// <summary>
        /// 平面検出を行う
        /// </summary>
        [SerializeField] private PlaneDetectionSystemManager _planeDetectionController;
        
        /// <summary>
        /// 光源推定を行う
        /// </summary>
        [SerializeField] private LightEstimationSystemManager _lightEstimationController;
 
        /// <summary>
        /// 全体のUIを管理する
        /// </summary>
        [SerializeField] private MainUI _mainUI;

        /// <summary>
        /// 設置するオブジェクト
        /// </summary>
        [SerializeField] private GameObject _placementPrefab;
        
        /// <summary>
        /// 設置するオブジェクトのキャッシュ
        /// </summary>
        private GameObject _instantiatedObject;

        private void Start()
        {
            Initialize();
            SetEvent();
        }

        private void Update()
        {
            _planeDetectionController.PlaneDetectionSetObject(_instantiatedObject);
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            _mainUI.Initialized();

            _planeDetectionController.Initialize();
            _lightEstimationController.Initialize();
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            this.OnCreatedObjectCallBack += () => _mainUI.SetIsCreated(true);
            _planeDetectionController.OnRaycastCallBack += CreateObject;
            _mainUI.OnClickCallBack += PlacedObjectDestroy;
        }

        /// <summary>
        /// 設置したオブジェクトを破壊
        /// </summary>
        private void PlacedObjectDestroy()
        {
            Destroy(_instantiatedObject);
        }

        /// <summary>
        /// /オブジェクトを生成する
        /// </summary>
        /// <param name="position">オブジェクトの設置場所</param>
        private void CreateObject(Vector3 position)
        {
            _instantiatedObject = Instantiate(_placementPrefab, position, Quaternion.identity) as GameObject;
            OnCreatedObjectCallBack?.Invoke();
        }
    }
}