using System;
using UI.Result.ResetButton;
using UniRx;
using Zenject;

namespace UI.ResetButton
{
    public class ResetButtonPresenter : IDisposable
    {
        /// <summary>
        /// クリックしたときに呼ばれる
        /// </summary>
        public event Action OnClickCallBack;
        
        /// <summary>
        /// View
        /// </summary>
        private ResetButtonView _view;
        
        /// <summary>
        /// Model
        /// </summary>
        private IResetButtonModel _model;

        /// <summary>
        /// PlacedObjectManager
        /// </summary>
        [Inject] private IPlacedObjectManager _placedObjectManager;

        /// <summary>
        /// Disposable
        /// </summary>
        private  CompositeDisposable _compositeDisposable;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResetButtonPresenter(IResetButtonModel model,ResetButtonView view)
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
            _model.IsCreatedProp
                .DistinctUntilChanged()
                .Subscribe(_view.SetShowView)
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            //クリックした時に設置したオブジェクトを破壊する
            _view.OnClickButton()
                .Subscribe(_=>OnClick())
                .AddTo(_compositeDisposable);

            //オブジェクトを生成したと時に、ボタンを表示する
            _placedObjectManager
                .OnCreatedObjectCallBack
                .Subscribe(_=>_model.SetIsCreated(true))
                .AddTo(_compositeDisposable);
        }
        
        /// <summary>
        /// ボタンをクリックした時のイベント
        /// </summary>.
        private void OnClick()
        {
            _placedObjectManager.PlacedObjectDestroy();
            _model.SetIsCreated(false);
            OnClickCallBack?.Invoke();
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