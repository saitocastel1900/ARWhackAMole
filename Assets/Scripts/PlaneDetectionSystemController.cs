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
  
    [SerializeField] private GameObject _placementPrefab;

    private Vector3 _touchPosition;
    private GameObject _instantiatedObject;
    
    public void Initialize()
    {
        if (_planeManager == null || _raycastManager == null || _placementPrefab==null)
        {
            Application.Quit();
        }
    }

    public void PlaneDetectionSetObject()
    {
        if (_instantiatedObject != null)
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

            if (Physics.Raycast(ray, out raycastHit, 30.0f))
            {
                if (_instantiatedObject == null)
                {
                    CreateObject(raycastHit.point);
                }
                else
                {
                    SetObject(raycastHit.point);
                }
            }
        }
#else
        if (Input.touchCount > 0)
        {
            _touchPosition = Input.GetTouch(0).position;
            var hits = new List<ARRaycastHit>();

            if (_raycastManager.Raycast(_touchPosition, hits, TrackableType.Planes))
            {
                if (_instantiatedObject == null)
                {
                    CreateObject(hits[0].pose.position);
                }
                else
                {
                    SetObject(hits[0].pose.position);
                }
            }
        }
#endif
    }

    public void SetInstanceNull()
    {
        Destroy(_instantiatedObject);
    }

    private void CreateObject(Vector3 position)
    {
        _instantiatedObject = Instantiate(_placementPrefab, position, Quaternion.identity) as GameObject;
        OnCreatedObjectCallBack?.Invoke();
    }

    private void SetObject(Vector3 position)
    {
        _instantiatedObject.transform.position = position;
    }
}
