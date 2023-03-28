using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enum
{
    public static class InGameEnum
    {
        /// <summary>
        /// 状態
        /// </summary>
        [Flags]
        public enum State
        {
            None      = 0,
            WaitStart = 1,
            Play      = 1 << 1,
            Finish    = 1 << 2,
        }
    }
}