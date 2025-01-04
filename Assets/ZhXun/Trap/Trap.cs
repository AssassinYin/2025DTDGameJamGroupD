using UnityEngine;

namespace ZhXun
{
    public class Trap : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                //碰到陷阱 遊戲結束
                GameOverManager.Instance.GameOver();
            }
        }
    }
}
