using Effect;
using UnityEngine;

namespace Effect
{
    public class InGameEffectManager : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        private DamageEffect _effectPrefab;

        /// <summary>
        /// 
        /// </summary>
        private EffectPool _pool;

        private void Awake()
        {
            //パーティクルを指定してオブジェクトプール作成
            _pool = new EffectPool(_effectPrefab);
        }

        /// <summary>
        /// 
        /// </summary>
        public void PlayEffect(Vector3 position)
        {
            //新たなParticlePlayerをプールから取得
            var effect = _pool.Rent();

            //パーティクルの位置をランダムに決定
            effect.transform.position = position;
            
            effect.transform.SetParent(this.transform);

            //パーティクルの再生を実行、再生が終わったらプールに戻す
            effect.Play(_pool.Return);
        }
    }
}