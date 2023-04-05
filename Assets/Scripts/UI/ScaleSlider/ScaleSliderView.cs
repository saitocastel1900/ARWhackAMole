using System;
using Const;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main.ScaleSlider
{
    public class ScaleSliderView : MonoBehaviour
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
            _slider.value=(InGameConst.PlacedObjectInitialScale-InGameConst.PlacedObjectMinScale)/(InGameConst.PlacedObjectMaxScale-InGameConst.PlacedObjectMinScale);
        }
        
        /// <summary>
        /// スライダーが動かいた時に呼ばれるObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<float> OnSliderValueChanged()
        {
            return _slider.OnValueChangedAsObservable();
        }

        /// <summary>
        /// オブジェクト表示する
        /// </summary>
        /// <param name="isInteractable">表示するかの真偽値</param>
        public void SetInteractable(bool isInteractable)
        {
            _slider.interactable = isInteractable;
        }
    }
}
