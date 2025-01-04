using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "FlashCard", menuName = "ScriptableObjects/CardEffects/FlashCard", order = 4)]
    public class FlashCard : CardEffect
    {
        [SerializeField] private Vector2 flashPos;

        public override void Execute()
        {
            //玩家閃現+flashPos
            MoveController player = Transform.FindFirstObjectByType<MoveController>();
            player.Teleport(flashPos);
        }
    }
}
