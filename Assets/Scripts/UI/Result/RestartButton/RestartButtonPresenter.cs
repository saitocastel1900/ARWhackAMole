using System;
using UniRx;
using Zenject;

namespace UI.Result.RestartButton
{
    public class RestartButtonPresenter : IDisposable, IInitializable
    {
        /// <summary>
        /// リスタートボタンが押されたときに呼ばれる
        /// </summary>
        public IObservable<Unit> OnRestartButtonClickCallBack=>_restartClickSubject;
        private readonly Subject<Unit> _restartClickSubject = new Subject<Unit>();

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
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            _view.OnClickButton()
                .Subscribe(_ => _restartClickSubject?.OnNext(Unit.Default))
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// 表示を更新
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