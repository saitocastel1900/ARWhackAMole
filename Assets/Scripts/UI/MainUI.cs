using UI.Main.DebugMessage;
using UI.Main.ResetButton;
using UI.Main.RotationSlider;
using UI.Main.ScaleSlider;
using UI.Main.ScoreText;
using UI.Result;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Main
{
    public class MainUI : MonoBehaviour
    {
        /// <summary>
        /// Button
        /// </summary>
        [Inject] private ResetButtonPresenter _resetButton;
        
        /// <summary>
        /// DebugText
        /// </summary>
        [Inject] private DebugMessagePresenter _messageText;

        /// <summary>
        /// ScaleSlider
        /// </summary>
        [Inject] private ScaleSliderPresenter _scaleSlider;
        
        /// <summary>
        /// RotationSlider
        /// </summary>
        [Inject] private RotationSliderPresenter _rotationSlider;

        /// <summary>
        /// ScoreText
        /// </summary>
        [Inject] private ScoreTextPresenter _scoreText;

        /// <summary>
        /// Result
        /// </summary>
        [Inject] private ResultUI _result;

        private void Start()
        {
            SetEvent();
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            //スコアが一定よりオーバーしたら、リザルトを表示する
            _scoreText.OnScoreOverCallBack
                .Subscribe(_=> _result.SetView(true))
                .AddTo(this.gameObject);
            
            //リスタートボタンが押されたら、スコアをリセットする
            _result.OnRestartButtonClickCallBack
                .Subscribe(_=> _scoreText.Reset())
                .AddTo(this.gameObject);
        }

        /// <summary>
        /// スコアを加算
        /// </summary>
        public void AddScore()
        {
            _scoreText.AddScore();
        }
    }
}