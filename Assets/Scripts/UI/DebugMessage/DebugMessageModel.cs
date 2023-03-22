using UniRx;

namespace UI.DebugMessage
{
    public class DebugMessageModel : IDebugMessageModel
    {
        /// <summary>
        /// 表示したい文字
        /// </summary>
        public IReactiveProperty<string> MessageTextProp => _messageTextProp;
        private StringReactiveProperty _messageTextProp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DebugMessageModel()
        {
            _messageTextProp = new StringReactiveProperty(" ");
        }
        
        /// <summary>
        /// 文字を表示する
        /// </summary>
        /// <param name="message">表示したい文字</param>
        public void SetMessageText(string message)
        {
            _messageTextProp.Value = message;
        }
    }
}