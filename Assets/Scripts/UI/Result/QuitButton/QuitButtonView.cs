using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

namespace UI.Result.QuitButton
{
    public class QuitButtonView : MonoBehaviour
    {
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            _button.gameObject.SetActive(isActive);
        }
    }
}