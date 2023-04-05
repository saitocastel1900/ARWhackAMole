using UnityEngine;
using UnityEngine.UI;

namespace UI.Main.DebugMessage
{
    public class DebugMessageView : MonoBehaviour
    {
        /// <summary>
        /// Text
        /// </summary>
        [SerializeField] private Text _messageText;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _messageText.gameObject.GetComponent<Text>().enabled = false;
        }
        
        /// <summary>
        /// 追加で文字を設定する
        /// </summary>
        /// <param name="text">設定したい文字</param>
        public void AddMessage(string text)
        {
            _messageText.text += $"{text}\r\n";
        }
    }
}