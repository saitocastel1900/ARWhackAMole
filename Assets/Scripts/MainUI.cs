using UI.DebugMessage;
using UI.ResetButton;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField] private ResetButtonPresenter _resetButton;
        
        /// <summary>
        /// Text
        /// </summary>
        [SerializeField] private DebugMessagePresenter _messageText;

        /// <summary>
        /// ボタンをクリックした時に呼ばれる
        /// </summary>
        public event UnityAction OnClickCallBack;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _resetButton.Initialize();
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
        /// 
        /// </summary>
        /// <param name="IsCreated"></param>
        public void SetIsCreated(bool IsCreated)
        {
            _resetButton.SetIsCreated(IsCreated);
        }
    }
}