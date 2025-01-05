using UnityEngine;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "NormalLightCard", menuName = "ScriptableObjects/CardEffects/NormalLightCard", order = 5)]
    public class NormalLightCard : CardEffect
    {
        [SerializeField] float roundEndDelay = 3;
        public override void Execute()
        {
            PlayerLight playerLight = Transform.FindFirstObjectByType<PlayerLight>();

            playerLight.SetNormalLight();

            CardSystem cardSystem = Transform.FindFirstObjectByType<CardSystem>();
            cardSystem.RoundEnd(roundEndDelay);
        }
    }
}
