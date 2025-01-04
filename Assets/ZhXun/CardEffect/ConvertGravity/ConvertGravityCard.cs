using UnityEngine;
using YEET;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "ConvertGravityCard", menuName = "ScriptableObjects/CardEffects/ConvertGravityCard", order = 5)]
    public class ConvertGravityCard : CardEffect
    {
        public override void Execute()
        {
            //轉換重力
            RotateScene rotateScene = Transform.FindFirstObjectByType<RotateScene>();

            rotateScene.Rotate();
        }
    }
}
