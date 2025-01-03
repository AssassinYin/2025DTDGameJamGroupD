using UnityEngine;

namespace ZhengHua
{
    /// <summary>
    /// San值扣除物件
    /// </summary>
    public abstract class SanObject : InteracitiveObject
    {
        /// <summary>
        /// 碰觸後須扣除的San值
        /// </summary>
        [SerializeField]
        private float sanValue = 0f;
        public override void Execute()
        {
            /// 呼叫玩家數值管理器的扣除San值方法
            Debug.Log("扣除San值: " + sanValue);
        }
    }
}
