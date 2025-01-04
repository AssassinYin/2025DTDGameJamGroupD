using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "MoveCard", menuName = "ScriptableObjects/CardEffects/MoveCard", order = 2)]
    public class MoveCard : CardEffect
    {
        [SerializeField] private int steps;

        public override void Execute()
        {
            //玩家移動steps格
            MoveController player = Transform.FindFirstObjectByType<MoveController>();
            player.Move(steps);
        }
    }
}
