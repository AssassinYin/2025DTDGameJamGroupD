using UnityEngine;
using UnityEngine.Rendering.Universal;
using YEET;

public class LightController : MonoBehaviour
{
    Animator GlobalLightAnim;
    Animator SpotLightAnim;

    [SerializeField] bool LightState;

    void Start()
    {
        //取得會受到開關燈影響的光源
        GlobalLightAnim = GameObject.Find("GlobalLight").GetComponent<Animator>();
        SpotLightAnim = GameObject.Find("PlayerSpotLight").GetComponent<Animator>();

        LightState = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetLight(!LightState);
        }
    }

    public void SetLight(bool flag)
    {
        if (flag) LightOn();
        else LightOff() ;
    }

    public void LightOn()
    {
        LightState = true;
        GlobalLightAnim.SetBool("LightOn", true);
        SpotLightAnim.SetBool("LightOn", true);
    }

    public void LightOff()
    {
        LightState = false;
        GlobalLightAnim.SetBool("LightOn", false);
        SpotLightAnim.SetBool("LightOn", false);
    }
}
