using UniRx;

namespace UI.Main.ResetButton
{
    public class ResetButtonModel : IResetButtonModel
    {
        /// <summary>
        /// インタラクション可能かどうか
        /// </summary>
        public IReactiveProperty<bool> IsInteractableProp => _isInteractableProp;
        private BoolReactiveProperty _isInteractableProp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResetButtonModel()
        {
            _isInteractableProp = new BoolReactiveProperty(false);
        }

        /// <summary>
        /// インタラクションを設定する
        /// </summary>
        /// <param name="IsInteractable">設定したい真偽値</param>
        public void SetIsInteractable(bool IsInteractable)
        {
            _isInteractableProp.Value = IsInteractable;
        }
    }
}