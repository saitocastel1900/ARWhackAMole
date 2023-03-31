using System;
using UniRx;

namespace UI.ScoreText
{
    public class ScoreTextPresenter: IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action OnScoreOverCallBack;
        
        /// <summary>
        /// Model
        /// </summary>
        private IScoreTextModel _model;
        
        /// <summary>
        /// View
        /// </summary>
        private ScoreTextView _view;

        /// <summary>
        /// Disposable
        /// </summary>
        private CompositeDisposable _compositeDisposable;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ScoreTextPresenter(IScoreTextModel model,ScoreTextView view)
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
            _model
                .ScoreProp
                .Subscribe(_view.SetText)
                .AddTo(_compositeDisposable);
        }

        private void SetEvent()
        {
            _model.OnScoreOverCallBack += ()=> OnScoreOverCallBack?.Invoke();
        }
        
        /// <summary>
        /// スコアを加算する
        /// </summary>
        public void AddScore()
        {
            _model.AddScore();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _model.Reset();
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