using UnityEngine;
using ZhengHua;

namespace ZhXun
{
    public class ProtectiveEffect : MonoBehaviour
    {
        [SerializeField] int round = 2;

        void Start()
        {
            PlayerManager.Instance.OnRoundEnd.AddListener(DestroyProtective);
        }

        void DestroyProtective()
        {
            round--;

            if(round <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
