using System;
using UniRx;
using Zenject;

namespace UI.Main.ResetButton
{
    public class ResetButtonPresenter : IDisposable , IInitializable
    {
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
        private IPlacedObjectManager _placedObjectManager;

        /// <summary>
        /// Disposable
        /// </summary>
        private  CompositeDisposable _compositeDisposable;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResetButtonPresenter(IResetButtonModel model,ResetButtonView view,IPlacedObjectManager placedObjectManager)
        {
            _model = model;
            _view = view;
            _placedObjectManager = placedObjectManager;
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
            _model.IsInteractableProp
                .DistinctUntilChanged()
                .Subscribe(_view.SetInteractable)
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            //クリックした時に設置したオブジェクトを破壊する
            _view.OnClickButton()
                .Subscribe(_=>_placedObjectManager.PlacedObjectDestroy())
                .AddTo(_compositeDisposable);

            //オブジェクトを生成したと時に、ボタンを表示する
            _placedObjectManager
                .CreatedObjectPrp
                .Subscribe(_model.SetIsInteractable)
                .AddTo(_compositeDisposable);
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