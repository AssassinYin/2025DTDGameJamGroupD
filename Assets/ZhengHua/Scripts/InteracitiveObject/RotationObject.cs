using UnityEngine;
using YEET;

namespace ZhengHua
{
    /// <summary>
    /// 可蒐集的物件
    /// </summary>
    public class RotationObject : InteracitiveObject
    {
        /// <summary>
        /// 對應的物件編號
        /// </summary>
        [SerializeField]
        private RotateScene rotateScene;

        private void Start()
        {
            rotateScene = FindFirstObjectByType<RotateScene>();
        }

        public override void Execute()
        {
            rotateScene?.Rotate(90);
            Destroy(gameObject);
        }
    }
}
