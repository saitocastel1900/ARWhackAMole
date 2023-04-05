using UniRx;

namespace UI.Main.ResetButton
{
    public interface IResetButtonModel
    {
        /// <summary>
        /// インタラクション可能かどうか
        /// </summary>
        public IReactiveProperty<bool> IsInteractableProp { get; }

        /// <summary>
        /// インタラクションを設定する
        /// </summary>
        /// <param name="IsInteractable">設定したい真偽値</param>
        public void SetIsInteractable(bool IsInteractable);
    }
}