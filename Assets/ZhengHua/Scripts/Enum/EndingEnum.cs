using UnityEngine;

namespace ZhengHua
{
    public enum EndingEnum
    {
        None,
        /// <summary>
        /// 死亡結局_空間裂隙
        /// </summary>
        DeadSpaceRift,
        /// <summary>
        /// 死亡結局_古神化身
        /// </summary>
        DeadElderGods,
        /// <summary>
        /// San 值歸零
        /// </summary>
        DeadSanZero,
        /// <summary>
        /// 基礎通關
        /// </summary>
        NormalSucceed,
        /// <summary>
        /// 取得舊神之力的真結局
        /// </summary>
        TureSucceed,
    }
}