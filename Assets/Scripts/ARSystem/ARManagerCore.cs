using System;
using UniRx;
using UnityEngine;

namespace ARManager
{
    public class ARManagerCore : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnInitializeAsync => _onInitializeAsyncSubject;
        private readonly AsyncSubject<Unit> _onInitializeAsyncSubject = new AsyncSubject<Unit>();

        private void Awake()
        {
            _onInitializeAsyncSubject.OnNext(Unit.Default);
            _onInitializeAsyncSubject.OnCompleted();
        }
    }
}