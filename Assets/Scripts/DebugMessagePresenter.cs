using UnityEngine.UI;
using UnityEngine;

namespace UI.DebugMessage
{
    public class DebugMessagePresenter : MonoBehaviour
    {
        /// <summary>
        /// Text
        /// </summary>
        [SerializeField] private Text _messageText;

        /// <summary>
        /// 上書きする形で文字を設定する
        /// </summary>
        /// <param name="text">設定したい文字</param>
        public void ShowMessage(string text)
        {
            _messageText.text = $"{text}\r\n";
        }

        /// <summary>
        /// 追加で文字を設定する
        /// </summary>
        /// <param name="text">設定したい文字</param>
        public void AddMessage(string text)
        {
            _messageText.text += $"{text}\r\n";
        }

        /// <summary>
        /// 真偽値に対応した○×を返す
        /// </summary>
        /// <param name="label"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public string SetTextForUI<T>(string label, T? data) where T : struct
        {
            var result = data.HasValue ? "〇" : "×";
            return $"{label}:{result}";
        }
    }
}