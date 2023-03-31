using UniRx;

namespace UI.Result.ResetButton
{
    public interface IResetButtonModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<bool> IsCreatedProp { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsCreated">設定したい真偽値</param>
        public void SetIsCreated(bool IsCreated);
    }
}