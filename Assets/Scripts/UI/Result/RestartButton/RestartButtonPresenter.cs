using System;
using UniRx;
using Zenject;

namespace UI.Result.RestartButton
{
    public class RestartButtonPresenter : IDisposable, IInitializable
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action OnResetButtonClickCallBack;
        
        /// <summary>
        /// Model
        /// </summary>
        private IRestartButtonModel _model;

        /// <summary>
        /// View
        /// </summary>
        private RestartButtonView _view;


        /// <summary>
        /// Disposable
        /// </summary>
        private CompositeDisposable _compositeDisposable;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RestartButtonPresenter(IRestartButtonModel model, RestartButtonView view)
        {
            _model = model;
            _view = view;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _compositeDisposable = new CompositeDisposable();
            Bind();
            SetEvent();
        }

        /// <summary>
        /// Bind
        /// </summary>
        private void Bind()
        {
            _model.IsShowProp
                .DistinctUntilChanged()
                .Subscribe(_view.SetActive)
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetEvent()
        {
            _view.OnClickButton()
                .Subscribe(_ => OnClickEvent())
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnClickEvent()
        {
            OnResetButtonClickCallBack?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isShow"></param>
        public void SetIsShow(bool isShow)
        {
            _model.SetIsShow(isShow);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}