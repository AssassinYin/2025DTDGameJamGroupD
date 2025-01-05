using Taco;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GoToPrologue : MonoBehaviour
{
    public void PlayClickSound()
    {
        SoundManager.PlaySound(SoundType.Click);
    }

    public void LoadPrologue()
    {
        SceneManager.LoadScene("Prologue");
    }
}
