using UniRx;

namespace UI.Main.ScaleSlider
{
    public interface IScaleSliderModel
    {
        /// <summary>
        /// オブジェクトを生成したかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsInteractableProp { get; }

        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsInteractable">設定したい真偽値</param>
        public void SetIsInteractable(bool IsInteractable);
    }
}