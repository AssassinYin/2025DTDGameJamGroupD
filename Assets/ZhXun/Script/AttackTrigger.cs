using UnityEngine;

namespace ZhXun
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] float liftTime;

        void Start()
        {
            Invoke("DestroySelf" , liftTime);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }

        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
