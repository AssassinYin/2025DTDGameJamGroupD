using UnityEngine;

namespace ZhengHua
{
    public enum EndingEnum
    {
        None,
        /// <summary>
        /// 死亡結局_時間裂隙
        /// </summary>
        DeadTimeRift,
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
        /// <summary>
        /// 死亡結局_敵人殺死
        /// </summary>
        DeadEnemy,
        /// <summary>
        /// 死亡結局_摔死
        /// </summary>
        DeadFail,
    }
}