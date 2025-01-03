using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "JumpCard", menuName = "ScriptableObjects/CardEffects/JumpCard", order = 3)]
    public class JumpCard : CardEffect
    {
        [SerializeField] private int high;

        public override void Execute()
        {
            //玩家跳躍high格
            Debug.Log("玩家跳躍:" + high + "格");
            MoveController player = Transform.FindFirstObjectByType<MoveController>();
            player.Jump(high);
        }
    }
}
