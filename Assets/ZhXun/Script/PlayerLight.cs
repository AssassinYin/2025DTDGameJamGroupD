using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ZhXun
{

    public class PlayerLight : MonoBehaviour
    {
        [SerializeField] float normalLightSize;
        [SerializeField] float reducedLightSize;
        [SerializeField] Light2D light2D;

        public void SetNormalLight()
        {
            light2D.pointLightInnerRadius = normalLightSize;
        }

        public void SetReducedLight()
        {
            light2D.pointLightInnerRadius = reducedLightSize;
        }        
    }
}
