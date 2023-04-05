using System;
using UI.Result.QuitButton;
using UI.Result.RestartButton;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Result
{
    public class ResultUI : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnRestartButtonClickCallBack=>_restartClickSubject;
        private readonly Subject<Unit> _restartClickSubject = new Subject<Unit>();


        /// <summary>
        /// 
        /// </summary>
        [Inject] private RestartButtonPresenter _restart;

        /// <summary>
        /// 
        /// </summary>
        [Inject] private QuitButtonPresenter _quit;

        //TODO:背景は表示・非表示だけなので、クラスで分けなかったが、今後は分ける予定
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private GameObject _backgroundPanel;

        private void Start()
        {
            //
            SetView(false);
            SetEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetEvent()
        {
            _restart.OnRestartButtonClickCallBack
                .Subscribe(_ =>
                {
                    _restartClickSubject?.OnNext(Unit.Default);
                    this.SetView(false);
                })
                .AddTo(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetView(bool value)
        {
            _backgroundPanel.SetActive(value);
            _quit.SetIsShow(value);
            _restart.SetIsShow(value);
        }
    }
}