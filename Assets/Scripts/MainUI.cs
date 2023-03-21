using UnityEngine;
using UnityEngine.Events;

public class MainUI : MonoBehaviour
{
    [SerializeField] private ResetButtonPresenter _resetButton;
    [SerializeField] private DebugMessagePresenter _messageText; 

    /// <summary>
    /// 
    /// </summary>
    public event UnityAction OnClickCallback;

    /// <summary>
    /// 
    /// </summary>
    public void Initialized()
    {
        _resetButton.Initialize();
        SetEvent();
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetEvent()
    {
        _resetButton.OnClickCallBack += ()=> OnClickCallback?.Invoke();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IsCreated"></param>
    public void SetIsCreated(bool IsCreated)
    {
        _resetButton.SetIsCreated(IsCreated);   
    }
}