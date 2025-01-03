using UnityEngine;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "MoveCard", menuName = "ScriptableObjects/CardEffects/MoveCard", order = 2)]
    public class MoveCard : CardEffect
    {
        [SerializeField] private int steps;

        public override void Execute()
        {
            //玩家移動steps格
            Debug.Log("玩家移動:" + steps + "格");
        }
    }
}
