using System;
using BlackbeardCrisis;
using UniRx;
using Zenject;

namespace UI.ScaleSlider
{
    public class ScaleSliderPresenter : IDisposable
    {
        /// <summary>
        /// Model
        /// </summary>
        private IScaleSliderModel _model;

        /// <summary>
        /// View
        /// </summary>
        private ScaleSliderView _view;

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
        public ScaleSliderPresenter(IScaleSliderModel model,ScaleSliderView view)
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
            _view.Initialize();
            Bind();
            SetEvent();
        }

        /// <summary>
        /// Bind
        /// </summary>
        private void Bind()
        {
            _model.IsCreatedProp
                .Subscribe(_view.SetShowView)
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            //スライダーを動かしたら、オブジェクトの大きさを変える
            _view.OnSliderValueChanged()
                .DistinctUntilChanged()
                .Subscribe(OnValueChanged)
                .AddTo(_compositeDisposable);
            
            //オブジェクトが生成されたら、スライダーを表示する
            _placedObjectManager
                .OnCreatedObjectCallBack
                .Subscribe(_=>
                {
                    _model.SetIsCreated(true);
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
            _placedObjectManager.GetPlacedObject()?.GetComponent<BlackbeardCrisisScaleAndRotation>().ScaleChanged(value);
        }

        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsCreated">設定したい真偽値</param>
        public void SetIsCreated(bool IsCreated)
        {
            _model.SetIsCreated(IsCreated);
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