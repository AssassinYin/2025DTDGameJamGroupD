using UnityEngine;
using UnityEngine.SceneManagement;

namespace Taco
{
    public class GameStarter : MonoBehaviour
    {
        public void EnterGame()
        {
            SoundManager.PlaySound(SoundType.Click);
            SceneManager.LoadScene("FinalScene");
        }
    }
}
