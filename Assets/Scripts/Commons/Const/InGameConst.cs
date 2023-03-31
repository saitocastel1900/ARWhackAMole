using UnityEngine;

namespace Const
{
    public class InGameConst
    {
        /// <summary>
        /// 設置するオブジェクトのID
        /// </summary>
        public const string PlacedObjectId = "player_01";

        /// <summary>
        /// 設置時の大きさ
        /// </summary>
        public const float PlacedObjectInitialScale=1f;

        /// <summary>
        /// 最小の大きさ
        /// </summary>
        public const float PlacedObjectMinScale = 0.2f;

        /// <summary>
        /// 最大の大きさ
        /// </summary>
        public const float PlacedObjectMaxScale = 2f;

        /// <summary>
        /// 設置時の角度
        /// </summary>
        public static readonly Quaternion PlacedObjectInitialRotation = Quaternion.identity;
        
        /// <summary>
        /// 最小の角度
        /// </summary>
        public const float PlacedObjectMinRotation = 0f;

        /// <summary>
        /// 最大の角度
        /// </summary>
        public const float PlacedObjectMaxRotation = 360f;
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly  Vector3 MoleInitialLocalPosition = new Vector3(0,0.005f,0);
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly  Vector3 MoleDivingLocalPosition = MoleInitialLocalPosition - new Vector3(0, 0.2f, 0);
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly  Vector3 DamageEffectPosition = new Vector3(0, 0.04f, 0);
    }
}