using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZhengHua;

namespace ZhXun
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;
        Vector2 defaultGravity; // 默認重力方向
        [SerializeField]
        private Sprite badEnding;
        [SerializeField]
        private Sprite badEnding2;
        [SerializeField]
        private Sprite goodEnding;
        [SerializeField]
        private Sprite normalEnding;
        [SerializeField]
        private Image spriteRenderer;
        [SerializeField]
        private TMP_Text text;

        void Start()
        {
            GameOverManager.Instance.OnGameOver.AddListener(OpenGameOverUI);
            defaultGravity = Physics2D.gravity;
        }

        void OpenGameOverUI()
        {
            switch (PlayerManager.Instance.ending)
            {
                case EndingEnum.DeadSanZero:
                    spriteRenderer.sprite = badEnding2;
                    text.text = "San 值歸零";
                    break;
                case EndingEnum.DeadEnemy:
                    spriteRenderer.sprite = badEnding;
                    text.text = "你被敵人殺死了";
                    break;
                case EndingEnum.NormalSucceed:
                    spriteRenderer.sprite = normalEnding;
                    text.text = "你通關了";
                    break;
                case EndingEnum.TureSucceed:
                    spriteRenderer.sprite = goodEnding;
                    text.text = "你真正的通關了";
                    break;
                case EndingEnum.DeadFail:
                    spriteRenderer.sprite = badEnding;
                    text.text = "你摔死了";
                    break;
                default:
                    text.text = "Game Over";
                    break;
            }
            spriteRenderer.gameObject.SetActive(PlayerManager.Instance.ending != EndingEnum.None);
            gameOverUI.SetActive(true);
        }

        public void Restart()
        {
            Physics2D.gravity = defaultGravity;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
