using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public static class AnimationUtility
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly float Duration = 1.0f;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public static Tween MoveYTween(Transform transform,float endValue)
        {
            return transform.DOLocalMoveY(endValue,Duration);
        }
    }
}