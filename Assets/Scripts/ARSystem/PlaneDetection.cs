using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ARManager
{
    [RequireComponent(typeof(ARPlaneManager))]
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaneDetection : BaseARManager
    {
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
        protected override void OnInitialize()
        {
            if (_planeManager == null || _raycastManager == null)
            {
                Application.Quit();
            }
        }

        private void Update()
        {
            PlaneDetectionSetObject();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PlaneDetectionSetObject()
        {
            if (_placedObjectManager.GetPlacedObject() != null)
            {
                foreach (var plane in _planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                return;
            }

#if UNITY_EDITOR
            if (_input.InputTapPush())
            {
                if (EventSystem.current.IsPointerOverGameObject()) return;
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, 30.0f))
                {
                    _placedObjectManager.PlacedObjectCreate(raycastHit.point,Quaternion.FromToRotation(Vector3.up,raycastHit.normal));
                }
            }
#elif UNITY_ANDROID
            if (_input.InputTapPush())
            {
                 if (EventSystem.current.IsPointerOverGameObject()) return;

                _touchPosition = Input.GetTouch(0).position;
                var hits = new List<ARRaycastHit>();

                if (_raycastManager.Raycast(_touchPosition, hits, TrackableType.Planes))
                {
                    _placedObjectManager.PlacedObjectCreate(hits[0].pose.position,hits[0].pose.rotation);
                }
            }
#endif
        }
    }
}