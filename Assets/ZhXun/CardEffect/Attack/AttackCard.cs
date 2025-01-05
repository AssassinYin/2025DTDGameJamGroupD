using UnityEngine;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "AttackCard", menuName = "ScriptableObjects/CardEffects/AttackCard", order = 6)]
    public class AttackCard : CardEffect
    {
        [SerializeField] int attackPoint;

        public override void Execute()
        {
            //玩家攻擊attackPoint方向
        }
    }
}
