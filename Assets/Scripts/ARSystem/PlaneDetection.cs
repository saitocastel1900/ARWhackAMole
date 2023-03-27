using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Zenject;

namespace ARSystem
{
    public class PlaneDetection : MonoBehaviour
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
        /// PlacedObjectManager
        /// </summary>
        [Inject] private IPlacedObjectManager _placedObjectManager;

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
        public void PlaneDetectionSetObject()
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
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, 30.0f) && _placedObjectManager.GetPlacedObject() == null)
                {
                    _placedObjectManager.PlacedObjectCreate(raycastHit.point,Quaternion.FromToRotation(Vector3.up,raycastHit.normal));
                }
            }
#else
            if (Input.touchCount > 0)
            {
                _touchPosition = Input.GetTouch(0).position;
                var hits = new List<ARRaycastHit>();

                if (_raycastManager.Raycast(_touchPosition, hits, TrackableType.Planes) && _placedObjectManager.GetPlacedObject()==null)
                {
                    _placedObjectManager.PlacedObjectCreate(hits[0].pose.position,hits[0].pose.rotation);
                }
            }
#endif
        }
    }
}