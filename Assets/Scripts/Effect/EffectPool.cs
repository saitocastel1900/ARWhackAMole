using UniRx.Toolkit;

namespace Effect
{
    public class EffectPool : ObjectPool<DamageEffect>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DamageEffect _original;

        /// <summary>
        /// 
        /// </summary>
        public EffectPool(DamageEffect original)
        {
            //オリジナルは非表示に
            _original = original;
            _original.gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DamageEffect CreateInstance()
        {
            //オリジナルを複製してインスタンス作成(オリジナルと同じ親の下に配置)
            return DamageEffect.Instantiate(_original, _original.transform.parent);
        }
    }
}
