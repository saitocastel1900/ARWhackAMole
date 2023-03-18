using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class MainUI : MonoBehaviour
{
    [SerializeField] private ResetButtonPresenter _resetButton;

    public event UnityAction OnClickCallback;

    public void Initialized()
    {
        _resetButton.Initialize();
        SetEvent();
    }

    private void SetEvent()
    {
        _resetButton.OnClickCallBack += ()=> OnClickCallback?.Invoke();
    }
    
    public void SetIsCreated(bool IsCreated)
    {
        _resetButton.SetIsCreated(IsCreated);   
    }
}