using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZhXun
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;
        Vector2 defaultGravity; // 默認重力方向

        void Start()
        {
            GameOverManager.Instance.OnGameOver.AddListener(OpenGameOverUI);
            defaultGravity = Physics2D.gravity;
        }

        void OpenGameOverUI()
        {
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
