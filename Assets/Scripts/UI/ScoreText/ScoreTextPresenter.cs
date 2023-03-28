using System;
using UniRx;

namespace UI.ScoreText
{
    public class ScoreTextPresenter: IDisposable
    {
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
        
        /// <summary>
        /// スコアを加算する
        /// </summary>
        public void AddScore()
        {
            _model.AddScore();
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