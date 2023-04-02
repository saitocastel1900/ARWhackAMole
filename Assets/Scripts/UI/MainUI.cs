using UI.DebugMessage;
using UI.ResetButton;
using UI.Result;
using UI.RotationSlider;
using UI.ScaleSlider;
using UI.ScoreText;
using UnityEngine;
using Zenject;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        /// <summary>
        /// Button
        /// </summary>
        [Inject] private ResetButtonPresenter _resetButton;
        
        /// <summary>
        /// Text
        /// </summary>
        [Inject] private DebugMessagePresenter _messageText;

        /// <summary>
        /// Slider
        /// </summary>
        [Inject] private ScaleSliderPresenter _scaleSlider;
        
        /// <summary>
        /// Slider
        /// </summary>
        [Inject] private RotationSliderPresenter _rotationSlider;

        /// <summary>
        /// Text
        /// </summary>
        [Inject] private ScoreTextPresenter _scoreText;

        /// <summary>
        /// Result
        /// </summary>
        [SerializeField] private ResultUI _result;

        private void Start()
        {
            SetEvent();
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            _resetButton.OnClickCallBack += ()=>_rotationSlider.SetIsCreated(false);
            _resetButton.OnClickCallBack += ()=>_scaleSlider.SetIsCreated(false);
            _scoreText.OnScoreOverCallBack += () => _result.SetView(true);
            _result.OnResetButtonClickCallBack += _scoreText.Reset;
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