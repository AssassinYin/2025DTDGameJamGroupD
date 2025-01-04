using UnityEngine;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "SanRecoverCard", menuName = "ScriptableObjects/CardEffects/SanRecover", order = 7)]
    public class SanRecover : CardEffect
    {
        [SerializeField] float sanValue;

        public override void Execute()
        {
            SanManager sanManager = Transform.FindFirstObjectByType<SanManager>();

            sanManager.ChangeSan(sanValue);
        }
    }
}
