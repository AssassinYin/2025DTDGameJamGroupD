using UnityEngine;
using ZhXun;

namespace ZhengHua
{
    /// <summary>
    /// 死亡物件
    /// </summary>
    public class DeadObject : InteracitiveObject
    {
        /// <summary>
        /// 對應的死亡結局編號
        /// </summary>
        [SerializeField]
        private EndingEnum endingEnum = EndingEnum.None;
        public override void Execute()
        {
            /// 傳出玩家死亡的訊息，並且給予對應的死亡結局
            Debug.Log("玩家死亡，結局編號: " + endingEnum);
            GameOverManager.Instance.GameOver();
        }
    }
}
