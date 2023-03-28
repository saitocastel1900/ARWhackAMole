using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class RestartButtonPresenter : MonoBehaviour
{
    public event Action OnClickCallBack;

    [SerializeField] private Button _button;

    public void Initialize()
    {
        _button
            .OnClickAsObservable()
            .Subscribe(_=>OnClickCallBack?.Invoke())
            .AddTo(this);
    }
}
