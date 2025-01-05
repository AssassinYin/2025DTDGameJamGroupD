using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZhXun
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;

        void Start()
        {
            GameOverManager.Instance.OnGameOver.AddListener(OpenGameOverUI);
        }

        void OpenGameOverUI()
        {
            gameOverUI.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
