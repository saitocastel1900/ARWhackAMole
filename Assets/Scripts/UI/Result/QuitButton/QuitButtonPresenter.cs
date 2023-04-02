using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Result.QuitButton
{
    public class QuitButtonPresenter : IDisposable, IInitializable
    {
        /// <summary>
        /// Model
        /// </summary>
        private IQuitButtonModel _model;

        /// <summary>
        /// View
        /// </summary>
        private QuitButtonView _view;


        /// <summary>
        /// Disposable
        /// </summary>
        private CompositeDisposable _compositeDisposable;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QuitButtonPresenter(IQuitButtonModel model, QuitButtonView view)
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
        /// 
        /// </summary>
        private void SetEvent()
        {
            _view.OnClickButton()
                .Subscribe(_ => OnClickEvent())
                .AddTo(_compositeDisposable);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnClickEvent()
        {
            Application.Quit();
        }

        /// <summary>
        /// 
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