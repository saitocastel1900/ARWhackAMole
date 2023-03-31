using UniRx;
using UnityEngine;
using Zenject;

namespace ARManager
{
    public abstract class BaseARManager : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        protected ARManagerCore _arCore;
        
        /// <summary>
        /// 
        /// </summary>
        [Inject] protected IInputEventProvider _input;
        
        /// <summary>
        /// 
        /// </summary>
        [Inject] protected IPlacedObjectManager _placedObjectManager;

        private void Start()
        {
            _arCore = this.gameObject.GetComponent<ARManagerCore>();
            _arCore.OnInitializeAsync.Subscribe(_=>OnInitialize()).AddTo(this);
            
            OnStart();
        }

        protected virtual void OnStart() { }

        protected abstract void OnInitialize();
    }
}