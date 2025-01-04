using UnityEngine;

namespace ZhengHua
{
    public class InteracitiveSenser : MonoBehaviour
    {
        [SerializeField]
        private LayerMask targetLayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            // 判斷是否有接觸到可互動物件
            if ((targetLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                InteracitiveObject obj = other.GetComponent<InteracitiveObject>();
                if(obj != null && obj.isTouchExecute)
                {
                    obj.Execute();
                }
            }
        }
    }
}
