using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "ReducedLightCard", menuName = "ScriptableObjects/CardEffects/ReducedLightCard", order = 5)]
    public class ReducedLightCard : CardEffect
    {
        [SerializeField] int invincibleTurn;
        [SerializeField] float roundEndDelay = 3;
        [SerializeField] GameObject protectiveEffec;

        public override void Execute()
        {
            PlayerLight playerLight = Transform.FindFirstObjectByType<PlayerLight>();
            playerLight.SetReducedLight();

            PlayerManager.Instance.EnterInvincible(invincibleTurn);


            Transform playerTf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Instantiate(protectiveEffec, playerTf);

            CardSystem cardSystem = Transform.FindFirstObjectByType<CardSystem>();
            cardSystem.RoundEnd(roundEndDelay);
        }
    }
}
