using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class ResetButtonPresenter : MonoBehaviour
{
    public event UnityAction OnClickCallBack;

    [SerializeField] private ResetButtonView _view;
    private ResetButtonModel _model;

    public void Initialize()
    {
        _model = new ResetButtonModel();

        Bind();
    }

    private void Bind()
    {
        _model.IsCreatedProp
            .DistinctUntilChanged()
            .Subscribe(_view.SetShowView)
            .AddTo(this);
    }

    public void OnButtonClick()
    {
        OnClickCallBack?.Invoke();
        _model.SetIsCreated(false);
    }

    public void SetIsCreated(bool IsCreated)
    {
        _model.SetIsCreated(IsCreated);
    }
}
