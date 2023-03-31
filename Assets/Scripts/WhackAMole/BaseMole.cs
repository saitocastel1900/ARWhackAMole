using UniRx;
using UnityEngine;

namespace WhackAMole
{
    public abstract class BaseMole : MonoBehaviour
    {
        protected MoleCore _moleCore;

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