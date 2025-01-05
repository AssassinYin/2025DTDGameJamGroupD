using UnityEngine;
using UnityEngine.SceneManagement;

namespace Taco
{
    public class GameStarter : MonoBehaviour
    {
        public void EnterGame()
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}
