using UnityEngine;

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
    }
}
