using UniRx;

namespace UI.Result.ResetButton
{
    public interface IResetButtonModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<bool> IsInteractableProp { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsInteractable">設定したい真偽値</param>
        public void SetIsInteractable(bool IsInteractable);
    }
}