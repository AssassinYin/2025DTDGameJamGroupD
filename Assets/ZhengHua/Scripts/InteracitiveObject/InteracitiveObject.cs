using UnityEngine;

namespace ZhengHua
{
    /// <summary>
    /// 可互動物件的抽象類別
    /// </summary>
    public abstract class InteracitiveObject : MonoBehaviour
    {
        /// <summary>
        /// 是否碰觸時就會觸發
        /// </summary>
        public bool isTouchExecute = true;

        public abstract void Execute();
    }
}
