using TMPro;
using UnityEngine;

namespace UI.Main.ScoreText
{
    public class ScoreTextView : MonoBehaviour
    {
        /// <summary>
        /// Text
        /// </summary>
        [SerializeField] private TextMeshProUGUI _text;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            SetText(0);
        }
        
        /// <summary>
        /// スコアを表示する
        /// </summary>
        /// <param name="value"></param>
        public void SetText(int value)
        {
            _text.text = "Score:" + value.ToString();
        }
    }
}