using UnityEngine;

namespace ZhengHua
{
    /// <summary>
    /// 可蒐集的物件
    /// </summary>
    public class CollectionObject : InteracitiveObject
    {
        /// <summary>
        /// 對應的物件編號
        /// </summary>
        [SerializeField]
        private CollectionEnum collectionEnum = CollectionEnum.None;
        public override void Execute()
        {
            Debug.Log("玩家成功拾取特定物件: " + collectionEnum);
            Destroy(gameObject);
        }
    }
}
