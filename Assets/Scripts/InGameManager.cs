using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private PlaneDetectionSystemController _planeDetectionController;
    [SerializeField] private LightEstimationController _lightEstimationController;
    [SerializeField] private MainUI _mainUI;
    
    [SerializeField] private GameObject _placementPrefab;
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

    private void Initialize()
    {
        _mainUI.Initialized();
        _planeDetectionController.Initialize();
        _lightEstimationController.Initialize();
    }

    private void SetEvent()
    {
        _mainUI.OnClickCallback += PlacedObjectDestroy;
        _planeDetectionController.OnRaycastCallBack += CreateObject;
        _planeDetectionController.OnCreatedObjectCallBack+=()=>_mainUI.SetIsCreated(true);
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void PlacedObjectDestroy()
    {
        Destroy(_instantiatedObject);
    }

    /// <summary>
    /// /
    /// </summary>
    /// <param name="position"></param>
    private void CreateObject(Vector3 position)
    {
        _instantiatedObject = Instantiate(_placementPrefab, position, Quaternion.identity) as GameObject;
    }
}
