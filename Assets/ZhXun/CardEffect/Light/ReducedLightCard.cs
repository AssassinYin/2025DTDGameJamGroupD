using UnityEngine;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "ReducedLightCard", menuName = "ScriptableObjects/CardEffects/ReducedLightCard", order = 5)]
    public class ReducedLightCard : CardEffect
    {
        public override void Execute()
        {
            PlayerLight playerLight = Transform.FindFirstObjectByType<PlayerLight>();

            playerLight.SetReducedLight();
            /*將角色設為無敵*/
        }
    }
}
