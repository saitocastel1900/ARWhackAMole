using System;
using UI;
using UI.DebugMessage;
using UniRx;
using UnityEngine;
using Zenject;

namespace WhackAMole
{
    public class MoleCore : MonoBehaviour, IDamagable
    {
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnInitializeAsync => _onInitializeAsyncSubject;
        private readonly AsyncSubject<Unit> _onInitializeAsyncSubject = new AsyncSubject<Unit>();
        
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnDamagedCallBack => _damageSubject;
        private Subject<Unit> _damageSubject = new Subject<Unit>();

        [Inject] private MainUI _mainUI;

        private void Awake()
        {
            _onInitializeAsyncSubject.OnNext(Unit.Default);
            _onInitializeAsyncSubject.OnCompleted();

            _damageSubject
                .Subscribe(_=>_mainUI.AddScore())
                .AddTo(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Damage()
        {
            _damageSubject.OnNext(Unit.Default);
        }
    }
}