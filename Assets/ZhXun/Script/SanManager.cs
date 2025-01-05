using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ZhXun
{
    public class SanManager : MonoBehaviour
    {
        [SerializeField] float maxSan = 100;
        [SerializeField] float sanDecayPerSecond = 0.5f;
        float sanValue = 100;

        [SerializeField] Slider sanSlider;
        [SerializeField] Image sanImage;

        [SerializeField] Sprite[] sanSprite;

        public UnityEvent<float> onSanValueChanged;

        void Awake()
        {
            UpdateSanUI();
            InvokeRepeating("SanDecrease", 1, 1);
        }

        void SanDecrease()
        {
            ChangeSan(-sanDecayPerSecond);
        }

        public void ChangeSan(float amount)
        {
            
            sanValue += amount;
            if (sanValue > 100)
            {
                sanValue = 100;
            }

            onSanValueChanged.Invoke(sanValue);
            UpdateSanUI();

            if (sanValue <= 0)
            {
                GameOverManager.Instance.GameOver();
                Destroy(this);
            }
        }

        void UpdateSanUI()
        {
            sanSlider.value = sanValue / maxSan;

            int imageIndex = 3 - (int)((sanValue - 1) / 25);

            if (imageIndex >= 0 && imageIndex < 4)
            {
                sanImage.sprite = sanSprite[imageIndex];
            }
        }
    }
}
