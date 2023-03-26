using UnityEngine;

namespace Const
{
    public class InGameConst
    {
        /// <summary>
        /// 設置するオブジェクトのID
        /// </summary>
        public static string PlacedObjectId = "player_01";

        /// <summary>
        /// 設置時の大きさ
        /// </summary>
        public static float InitialScale=1f;

        /// <summary>
        /// 最小の大きさ
        /// </summary>
        public const float MinScale = 0.2f;

        /// <summary>
        /// 最大の大きさ
        /// </summary>
        public const float MaxScale = 2f;

        /// <summary>
        /// 設置時の角度
        /// </summary>
        public static Quaternion InitialRotation=Quaternion.identity;
        
        /// <summary>
        /// 最小の角度
        /// </summary>
        public const float MinRotation = 0f;

        /// <summary>
        /// 最大の角度
        /// </summary>
        public const float MaxRotation = 360f;
    }
}