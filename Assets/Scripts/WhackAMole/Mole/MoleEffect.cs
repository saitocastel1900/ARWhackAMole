using Const;
using Effect;
using UniRx;
using Zenject;

namespace WhackAMole.Mole
{
    public class MoleEffect : BaseMole
    {
        /// <summary>
        /// InGameEffectManager
        /// </summary>
        [Inject] private InGameEffectManager _effectManager;
        
        protected override void OnInitialize()
        {
            //ダメージを受けたら、エフェクトを流す
            _moleCore.OnDamagedCallBack
                .Subscribe(_ => _effectManager.PlayEffect(transform.position+InGameConst.DamageEffectPosition))
                .AddTo(this.gameObject);
        }
    }
}