using System;
using WhackAMole;
using UniRx;
using Zenject;

namespace UI.Main.RotationSlider
{
    public class RotationSliderPresenter : IDisposable , IInitializable
    {
        /// <summary>
        /// Model
        /// </summary>
        private IRotationSliderModel _model;

        /// <summary>
        /// View
        /// </summary>
        private RotationSliderView _view;

        /// <summary>
        /// PlacedObjectManager
        /// </summary>
        private IPlacedObjectManager _placedObjectManager;

        /// <summary>
        /// Disposable
        /// </summary>
        private CompositeDisposable _compositeDisposable;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RotationSliderPresenter(IRotationSliderModel model,RotationSliderView view, IPlacedObjectManager placedObjectManager)
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
            _view.Initialize();
            Bind();
            SetEvent();
        }

        /// <summary>
        /// Bind
        /// </summary>
        private void Bind()
        {
            _model.IsInteractableProp
                .Subscribe(_view.SetInteractable)
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            //スライダーを動かしたら、オブジェクトを回転させる
            _view.OnSliderValueChanged()
                .DistinctUntilChanged()
                .Subscribe(OnValueChanged)
                .AddTo(_compositeDisposable);

            //オブジェクトが作られたら、インタラクション可能にする
            _placedObjectManager
                .CreatedObjectPrp
                .Subscribe(value=>
                {
                    _model.SetIsInteractable(value);
                    _view.AdjustmentSliderPosition();
                })
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// スライダーを動かしたら呼ばれる
        /// </summary>
        /// <param name="value"></param>
        private void OnValueChanged(float value)
        {
            _placedObjectManager.GetPlacedObject()?.GetComponent<WhackAMoleScaleAndRotation>().RotationChanged(value);
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