using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private PlaneDetectionSystemController _planeDetection;
    [SerializeField] private MainUI _mainUI;

    private void Start()
    {
        Initialize();
        SetEvent();
    }

    private void Update()
    {
        _planeDetection.PlaneDetectionSetObject();
    }

    private void Initialize()
    {
        _planeDetection.Initialize();
        _mainUI.Initialized();
    }

    private void SetEvent()
    {
        _mainUI.OnClickCallback += _planeDetection.SetInstanceNull;
        _planeDetection.OnCreatedObjectCallBack+=()=>_mainUI.SetIsCreated(true);
    }
}
