using System;
using UniRx;
using UnityEngine.Events;

namespace UI.ResetButton
{
    public class ResetButtonPresenter : IDisposable
    {
        /// <summary>
        /// ボタンをクリックしたときに呼ばれる
        /// </summary>
        public event UnityAction OnClickCallBack;

        /// <summary>
        /// View
        /// </summary>
        private ResetButtonView _view;
        
        /// <summary>
        /// Model
        /// </summary>
        private ResetButtonModel _model;

        /// <summary>
        /// Disposable
        /// </summary>
        private  CompositeDisposable _compositeDisposable;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResetButtonPresenter(ResetButtonModel model,ResetButtonView view)
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
            _view.OnClickButton()
                .Subscribe(_=>OnButtonClick())
                .AddTo(_compositeDisposable);
        }
        
        /// <summary>
        /// ボタンをクリックした時のイベント
        /// </summary>
        private void OnButtonClick()
        {
            OnClickCallBack?.Invoke();
            _model.SetIsCreated(false);
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