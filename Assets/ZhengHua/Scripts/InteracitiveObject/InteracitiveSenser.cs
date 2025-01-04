using UnityEngine;

namespace ZhengHua
{
    public class InteracitiveSenser : MonoBehaviour
    {
        [SerializeField]
        private LayerMask targetLayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            // �P�_�O�_����Ĳ��i���ʪ���
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
