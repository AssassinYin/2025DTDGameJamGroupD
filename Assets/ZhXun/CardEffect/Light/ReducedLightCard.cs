using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "ReducedLightCard", menuName = "ScriptableObjects/CardEffects/ReducedLightCard", order = 5)]
    public class ReducedLightCard : CardEffect
    {
        [SerializeField] int invincibleTurn;

        public override void Execute()
        {
            PlayerLight playerLight = Transform.FindFirstObjectByType<PlayerLight>();

            playerLight.SetReducedLight();
            PlayerManager.Instance.EnterInvincible(invincibleTurn);
        }
    }
}
