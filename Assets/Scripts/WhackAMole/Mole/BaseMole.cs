using UniRx;
using UnityEngine;
using Zenject;

namespace WhackAMole.Mole
{
    public abstract class BaseMole : MonoBehaviour
    {
        //共通して使う物
        
        /// <summary>
        /// MoleCore
        /// </summary>
        protected MoleCore _moleCore;
       
        /// <summary>
        /// Input
        /// </summary>
        [Inject] protected IInputEventProvider _input;
        
        private void Start()
        {
            _moleCore = this.gameObject.GetComponent<MoleCore>();
            _moleCore.OnInitializeAsync.Subscribe(_=>OnInitialize()).AddTo(this);
            
            OnStart();
        }

        protected virtual void OnStart() { }

        protected abstract void OnInitialize();
    }
}