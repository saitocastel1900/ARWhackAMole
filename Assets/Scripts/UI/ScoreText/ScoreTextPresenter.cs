using System;
using UniRx;
using Zenject;

namespace UI.Main.ScoreText
{
    public class ScoreTextPresenter: IDisposable , IInitializable
    {
        /// <summary>
        /// スコアが一定値をオーバーした時に呼ばれる
        /// </summary>
        public IObservable<Unit> OnScoreOverCallBack=>_createdObjectSubject;
        private readonly Subject<Unit> _createdObjectSubject = new Subject<Unit>();

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

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            _model.OnScoreOverCallBack
                .Subscribe(_=> _createdObjectSubject?.OnNext(Unit.Default))
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
        /// リセット
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