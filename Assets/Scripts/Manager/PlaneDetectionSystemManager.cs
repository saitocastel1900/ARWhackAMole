using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Manager.ARSystemManager
{
    public class PlaneDetectionSystemManager : MonoBehaviour
    {
        /// <summary>
        /// 平面をレイキャストした時に呼ばれる
        /// </summary>
        public event Action<Vector3> OnRaycastCallBack;

        /// <summary>
        /// ARPlaneManager
        /// </summary>
        [SerializeField] private ARPlaneManager _planeManager;

        /// <summary>
        /// ARRaycastManager
        /// </summary>
        [SerializeField] private ARRaycastManager _raycastManager;

        /// <summary>
        /// スマートフォンをタッチした場所
        /// </summary>
        private Vector3 _touchPosition;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            if (_planeManager == null || _raycastManager == null)
            {
                Application.Quit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instantiatedObject"></param>
        public void PlaneDetectionSetObject(GameObject instantiatedObject)
        {
            if (instantiatedObject != null)
            {
                foreach (var plane in _planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                return;
            }

#if UNITY_EDITOR

            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                
                if (Physics.Raycast(ray, out raycastHit, 30.0f) && instantiatedObject == null)
                {
                    OnRaycastCallBack(raycastHit.point);
                }
            }
#else
            if (Input.touchCount > 0)
            {
                _touchPosition = Input.GetTouch(0).position;
                var hits = new List<ARRaycastHit>();

                if (_raycastManager.Raycast(_touchPosition, hits, TrackableType.Planes) && instantiatedObject == null)
                {
                    OnRaycastCallBack(hits[0].pose.position);
                }
            }
#endif
        }
    }
}