using UniRx;

namespace UI.ScaleSlider
{
    public class ScaleSliderModel : IScaleSliderModel
    {
        /// <summary>
        /// オブジェクトを生成したかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsInteractableProp => _isInteractableProp;

        private BoolReactiveProperty _isInteractableProp;

        /// <summary>
        /// 
        /// </summary>
        public ScaleSliderModel()
        {
            _isInteractableProp = new BoolReactiveProperty(false);
        }
        
        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsInteractable">設定したい真偽値</param>
        public void SetIsInteractable(bool IsInteractable)
        {
            _isInteractableProp.Value = IsInteractable;
        }
    }
}