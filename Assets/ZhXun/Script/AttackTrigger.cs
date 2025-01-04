using UnityEngine;

namespace ZhXun
{
    public class AttackTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
