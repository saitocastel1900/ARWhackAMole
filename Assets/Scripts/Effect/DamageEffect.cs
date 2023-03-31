using System;
using UnityEngine;

namespace Effect
{
    public class DamageEffect : MonoBehaviour
    {
        /// <summary>
        /// /
        /// </summary>
        private Action<DamageEffect> _playEffectCallBack;

        /// <summary>
        /// 実行
        /// </summary>
        public void Play(Action<DamageEffect> callback)
        {
            GetComponent<ParticleSystem>().Play();
            _playEffectCallBack = callback;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnParticleSystemStopped()
        {
            _playEffectCallBack(this);
        }
    }
}
