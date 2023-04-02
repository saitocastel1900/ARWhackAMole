using System;
using UniRx;
using Zenject;

namespace UI.DebugMessage
{
    public class DebugMessagePresenter : IDisposable , IInitializable
    {
        /// <summary>
        /// Model
        /// </summary>
        private  IDebugMessageModel _model;
        
        /// <summary>
        /// View
        /// </summary>
        private  DebugMessageView _view;

        /// <summary>
        /// Disposable
        /// </summary>
        private  CompositeDisposable _compositeDisposable;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DebugMessagePresenter(IDebugMessageModel model,DebugMessageView view)
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
        }

        /// <summary>
        /// Bind
        /// </summary>
        private void Bind()
        {
            _model.MessageTextProp
                .Subscribe(_view.AddMessage)
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// 文字を表示する
        /// </summary>
        /// <param name="message">表示したい文字</param>
        public void SetMessageText(string message)
        {
            _model.SetMessageText(message);
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