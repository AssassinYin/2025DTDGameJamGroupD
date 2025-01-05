using UnityEngine;

namespace ZhXun
{
    public class LowSanEffect : MonoBehaviour
    {
        [SerializeField] ParticleSystem ps;

        void Start()
        {
            SanManager sanManager = Transform.FindFirstObjectByType<SanManager>();
            sanManager.onSanValueChanged.AddListener(sanValueChanged);
        }

        void sanValueChanged(float value)
        {
            if(value > 50)
            {
                var emission = ps.emission;
                emission.rateOverTime = 0;
            }
            else if(value > 25)
            {
                var emission = ps.emission;
                emission.rateOverTime = (100 - (value + 50)) / 25;
            }
            else if(value <= 25)
            {
                var emission = ps.emission;
                emission.rateOverTime = (100 - value) / 20;
            }
            
        }
    }
}
