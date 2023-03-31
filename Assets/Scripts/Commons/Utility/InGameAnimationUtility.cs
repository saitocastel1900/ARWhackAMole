using Const;
using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public static class InGameAnimationUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static Tween MoleUpTween(Transform transform)
        {
            return AnimationUtility.MoveYTween(transform,InGameConst.MoleInitialLocalPosition.y);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static Tween MoleDownTween(Transform transform)
        {
            return AnimationUtility.MoveYTween(transform,InGameConst.MoleDivingLocalPosition.y);
        }
    }
}