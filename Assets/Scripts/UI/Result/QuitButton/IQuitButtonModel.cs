using UniRx;

namespace UI.Result.QuitButton
{
    public interface IQuitButtonModel
    {
        /// <summary>
        /// 表示をするかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsShowProp { get; }

        /// <summary>
        /// 表示を更新
        /// </summary>
        /// <param name="IsShow">設定したい真偽値</param>
        public void SetIsShow(bool IsShow);
    }
}