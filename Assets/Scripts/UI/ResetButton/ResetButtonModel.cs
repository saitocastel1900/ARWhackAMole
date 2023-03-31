using UI.Result.ResetButton;
using UniRx;

namespace UI.ResetButton
{
    public class ResetButtonModel : IResetButtonModel
    {
        /// <summary>
        /// オブジェクトを生成したかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsCreatedProp => _isCreatedProp;

        private BoolReactiveProperty _isCreatedProp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResetButtonModel()
        {
            _isCreatedProp = new BoolReactiveProperty(false);
        }

        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsCreated">設定したい真偽値</param>
        public void SetIsCreated(bool IsCreated)
        {
            _isCreatedProp.Value = IsCreated;
        }
    }
}