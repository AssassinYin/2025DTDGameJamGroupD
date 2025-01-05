using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "AttackCard", menuName = "ScriptableObjects/CardEffects/AttackCard", order = 6)]
    public class AttackCard : CardEffect
    {
        [SerializeField] int attackPoint;

        public override void Execute()
        {
            MoveController player = Transform.FindFirstObjectByType<MoveController>();
            player.CreateAttackObject(attackPoint);
            //PlayerManager.Instance.OnRoundEnd?.Invoke();
        }
    }
}
