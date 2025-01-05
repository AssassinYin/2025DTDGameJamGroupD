using UnityEngine;
using ZhengHua;
using System.Collections;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "AttackCard", menuName = "ScriptableObjects/CardEffects/AttackCard", order = 6)]
    public class AttackCard : CardEffect
    {
        [SerializeField] int attackPoint;
        [SerializeField] float roundEndDelay = 3;

        public override void Execute()
        {
            MoveController player = Transform.FindFirstObjectByType<MoveController>();
            player.CreateAttackObject(attackPoint);

            CardSystem cardSystem = Transform.FindFirstObjectByType<CardSystem>();
            cardSystem.RoundEnd(roundEndDelay);
        }
    }
}
