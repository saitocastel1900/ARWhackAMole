using System;
using UI.ResetButton;
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
    [SerializeField] private QuitButtonView _quit;

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

        _quit.OnClickButton()
            .Subscribe(_=>OnClickQuitButton())
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

    private void OnClickQuitButton()
    {
          Application.Quit();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void SetView(bool value)
    {
        this.gameObject.SetActive(value);
    }
}
