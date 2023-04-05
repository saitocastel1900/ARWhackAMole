using System;
using UI.DebugMessage;
using UI.Main;
using UniRx;
using UnityEngine;
using Zenject;

namespace WhackAMole.Mole
{
    public class MoleCore : MonoBehaviour, IDamagable
    {
        //外部にパラメータやイベントを公開する
        
        /// <summary>
        /// 初期化したか
        /// </summary>
        public IObservable<Unit> OnInitializeAsync => _onInitializeAsyncSubject;
        private readonly AsyncSubject<Unit> _onInitializeAsyncSubject = new AsyncSubject<Unit>();
        
        /// <summary>
        /// ダメージを受けたか
        /// </summary>
        public IObservable<Unit> OnDamagedCallBack => _damageSubject;
        private Subject<Unit> _damageSubject = new Subject<Unit>();

        /// <summary>
        /// MainUI
        /// </summary>
        [Inject] private MainUI _mainUI;

        private void Awake()
        {
            InitializeMole();

            _damageSubject
                .Subscribe(_=>_mainUI.AddScore())
                .AddTo(this);
        }
        
        //外部からモグラそれぞれに設定する値が必要だった場合のメソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void InitializeMole()
        {
            _onInitializeAsyncSubject.OnNext(Unit.Default);
            _onInitializeAsyncSubject.OnCompleted();
        }

        /// <summary>
        /// Damage
        /// </summary>
        public void Damage()
        {
            _damageSubject.OnNext(Unit.Default);
        }
    }
}