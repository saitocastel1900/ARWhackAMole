using System;

namespace WhackAMole.Mole
{
    [Serializable]
    public struct MoleParameter
    {
        /// <summary>
        /// もぐらの初期位置
        /// </summary>
        public float MoleInitialLocalPositionY;

        /// <summary>
        /// モグラの潜る位置
        /// </summary>
        public float MoleDivingLocalPositionY;

        /// <summary>
        /// ダメージエフェクトの発生位置
        /// </summary>
        public float DamageEffectPositionY;
    }
}