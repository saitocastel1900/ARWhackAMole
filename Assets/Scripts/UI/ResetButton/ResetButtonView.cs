using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ResetButton
{
    public class ResetButtonView : MonoBehaviour
    {
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField] private Button _button;

        /// <summary>
        /// ButtonのIObservableを返す
        /// </summary>
        public IObservable<Unit> OnClickButton()
        {
            return _button.OnClickAsObservable();
        }

        /// <summary>
        /// オブジェクト表示する
        /// </summary>
        /// <param name="isView">表示するかの真偽値</param>
        public void SetShowView(bool isView)
        {
            _button.interactable = isView;
        }
    }
}