using UnityEngine;

namespace ZhXun
{
    /*
    卡牌觸發效果的基類
    */
    public abstract class CardEffect : ScriptableObject
    {
        public abstract void Execute();
    }
}
