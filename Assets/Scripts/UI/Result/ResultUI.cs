using System;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public event Action OnClickCallBack;
    
    [SerializeField] private RestartButtonPresenter _restart;
    [SerializeField] private QuitButtonPresenter _quit;

    private void Start()
    {
        Initialize();
        SetEvent();

        SetView(false);
    }

    private void Initialize()
    {
        _restart.Initialize();
        _quit.Initialize();
    }

    private void SetEvent()
    {
        _restart.OnClickCallBack += () => OnClickCallBack?.Invoke();
        _restart.OnClickCallBack += () => SetView(false);
    }

    public void SetView(bool value)
    {
        this.gameObject.SetActive(value);
    }
}
