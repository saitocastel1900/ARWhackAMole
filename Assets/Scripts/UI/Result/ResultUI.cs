using System;
using UI.Result.QuitButton;
using UI.Result.RestartButton;
using UniRx;
using UnityEngine;
using Zenject;

public class ResultUI : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public event Action OnResetButtonClickCallBack;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private RestartButtonView _restart;
    
    /// <summary>
    /// 
    /// </summary>
    [Inject] private QuitButtonPresenter _quit;

    private void Start()
    {
        Initialize();
        SetEvent();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Initialize()
    {
        SetView(false);
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetEvent()
    {
        _restart.OnClickButton()
            .Subscribe(_=>OnClickRestartButton())
            .AddTo(this);
    }
    
    /// <summary>
    /// ボタンをクリックした時のイベント
    /// </summary>.
    private void OnClickRestartButton()
    {
        OnResetButtonClickCallBack?.Invoke();
        SetView(false);
    }
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void SetView(bool value)
    {
        this.gameObject.SetActive(value);
        _quit.SetIsShow(value);
    }
}
