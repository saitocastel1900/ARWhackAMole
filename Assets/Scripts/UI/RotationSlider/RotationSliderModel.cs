using UniRx;

namespace UI.RotationSlider
{
    public class RotationSliderModel : IRotationSliderModel
    {
        /// <summary>
        /// オブジェクトを生成したかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsCreatedProp => _isCreatedProp;

        private BoolReactiveProperty _isCreatedProp;

        /// <summary>
        /// 
        /// </summary>
        public RotationSliderModel()
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