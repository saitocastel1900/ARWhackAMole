using System;
using Const;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.RotationSlider
{
    public class RotationSliderView : MonoBehaviour
    {
        /// <summary>
        /// Slider
        /// </summary>
        [SerializeField] private Slider _slider;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            AdjustmentSliderPosition();
        }
        
        /// <summary>
        /// スライダーの位置を調整する
        /// </summary>
        public void AdjustmentSliderPosition()
        {
            _slider.value=(InGameConst.InitialRotation.eulerAngles.y-InGameConst.MinRotation)/(InGameConst.MaxRotation-InGameConst.MinRotation);
        }
        
        /// <summary>
        /// スライダーのObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<float> OnSliderValueChanged()
        {
            return _slider.OnValueChangedAsObservable();
        }

        /// <summary>
        /// オブジェクト表示する
        /// </summary>
        /// <param name="isView">表示するかの真偽値</param>
        public void SetShowView(bool isView)
        {
            _slider.interactable = isView;
        }
    }
}