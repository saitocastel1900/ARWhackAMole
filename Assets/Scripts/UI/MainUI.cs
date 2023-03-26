using UI.DebugMessage;
using UI.ResetButton;
using UI.RotationSlider;
using UI.ScaleSlider;
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

        private void Start()
        {
            Initialized();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialized()
        {
            _resetButton.Initialize();
            _messageText.Initialize();
            _scaleSlider.Initialize();
            _rotationSlider.Initialize();
            SetEvent();
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            _resetButton.OnClickCallBack += ()=>_rotationSlider.SetIsCreated(false);
            _resetButton.OnClickCallBack += ()=>_scaleSlider.SetIsCreated(false);
        }

        /// <summary>
        /// 文字を表示する
        /// </summary>
        /// <param name="message">表示したい文字</param>
        public void SetMessageText(string message)
        {
            _messageText.SetMessageText(message);
        }
    }
}