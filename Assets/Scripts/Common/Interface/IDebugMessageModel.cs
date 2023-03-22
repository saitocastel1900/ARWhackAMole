using UniRx;

namespace UI.DebugMessage
{
    public interface IDebugMessageModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IReactiveProperty<string> MessageTextProp { get; }

        /// <summary>
        /// 文字を表示する
        /// </summary>
        /// <param name="message">表示したい文字</param>
        public void SetMessageText(string message);
    }
}