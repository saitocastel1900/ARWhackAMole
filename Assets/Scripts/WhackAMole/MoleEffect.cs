using Const;
using Manager;
using UniRx;
using Zenject;

namespace WhackAMole
{
    public class MoleEffect : BaseMole
    {
        /// <summary>
        /// 
        /// </summary>
        [Inject] private InGameEffectManager _effectManager;
        
        protected override void OnInitialize()
        {
            _moleCore.OnDamagedCallBack
                .Subscribe(_ => _effectManager.PlayEffect(transform.position+InGameConst.DamageEffectPosition))
                .AddTo(this.gameObject);
        }
    }
}