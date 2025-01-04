using UnityEngine;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "NormalLightCard", menuName = "ScriptableObjects/CardEffects/NormalLightCard", order = 5)]
    public class NormalLightCard : CardEffect
    {
        public override void Execute()
        {
            PlayerLight playerLight = Transform.FindFirstObjectByType<PlayerLight>();

            playerLight.SetNormalLight();
        }
    }
}
