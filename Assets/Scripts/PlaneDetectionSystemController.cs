using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetectionSystemController : MonoBehaviour
{
    public event Action OnCreatedObjectCallBack;

    [SerializeField] private ARPlaneManager _planeManager;
    [SerializeField] private ARRaycastManager _raycastManager;

    private Vector3 _touchPosition;

    public event Action<Vector3> OnRaycastCallBack;

    public void Initialize()
    {
        if (_planeManager == null || _raycastManager == null)
        {
            Application.Quit();
        }
    }

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
                OnCreatedObjectCallBack?.Invoke();
            }
        }
#else
        if (Input.touchCount > 0)
        {
            _touchPosition = Input.GetTouch(0).position;
            var hits = new List<ARRaycastHit>();

            if (_raycastManager.Raycast(_touchPosition, hits, TrackableType.Planes)&&instantiatedObject == null)
            {
                OnRaycastCallBack(hits[0].pose.position);
                OnCreatedObjectCallBack?.Invoke();
            }
        }
#endif
    }
}