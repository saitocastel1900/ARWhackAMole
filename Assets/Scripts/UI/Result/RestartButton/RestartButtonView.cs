﻿using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace UI.Result.RestartButton
{
    public class RestartButtonView : MonoBehaviour
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
    }
}