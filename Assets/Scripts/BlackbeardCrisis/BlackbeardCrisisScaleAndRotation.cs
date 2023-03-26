﻿using UnityEngine;
using Const;

namespace BlackbeardCrisis
{
    public class BlackbeardCrisisScaleAndRotation : MonoBehaviour
    {
        /// <summary>
        /// 前回のY軸回転角度
        /// </summary>
        private float _prevRotationAngle = 0f;

        /// <summary>
        /// 拡縮を変える
        /// </summary>
        /// <param name="value">大きさ</param>
        public void ScaleChanged(float value)
        {
            var scale = value * (InGameConst.MaxScale - InGameConst.MinScale) + InGameConst.MinScale;
            transform.localScale = Vector3.one / scale;
        }

        /// <summary>
        /// 回転させる
        /// </summary>
        /// <param name="value">大きさ</param>
        public void RotationChanged(float value)
        {
            //Y軸の回転制限
            var rotY = value * (InGameConst.MaxRotation - InGameConst.MinRotation) + InGameConst.MinRotation;
            float rotationYDelta = rotY - _prevRotationAngle;
            var rotation = Quaternion.Euler(0, rotationYDelta, 0);
            transform.localRotation *= rotation;
            _prevRotationAngle = rotY;
        }
    }
}