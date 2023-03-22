using UI.DebugMessage;
using UI.ResetButton;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        /// <summary>
        /// ボタンをクリックした時に呼ばれる
        /// </summary>
        public event UnityAction OnClickCallBack;
        
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField] private ResetButtonPresenter _resetButton;
        
        /// <summary>
        /// Text
        /// </summary>
        [Inject] private DebugMessagePresenter _messageText;
        
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _resetButton.Initialize();
            _messageText.Initialize();
            SetEvent();
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        private void SetEvent()
        {
            _resetButton.OnClickCallBack += () => OnClickCallBack?.Invoke();
        }

        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsCreated">設定したい真偽値</param>
        public void SetIsCreated(bool IsCreated)
        {
            _resetButton.SetIsCreated(IsCreated);
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