using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

namespace ZhXun
{

    public class PlayerLight : MonoBehaviour
    {
        [SerializeField] float normalLightSize;
        [SerializeField] float reducedLightSize;
        public float transitionDuration = 1f;

        [SerializeField] Gradient SanlightColor;

        [SerializeField] Light2D light2D;

        Coroutine currentCoroutine;

        void Start()
        {
            SanManager sanManager = Transform.FindFirstObjectByType<SanManager>();
            sanManager.onSanValueChanged.AddListener(UpdateSanLight);
        }

        public void SetNormalLight()
        {
            StartLightTransition(normalLightSize);
        }

        public void SetReducedLight()
        {
            StartLightTransition(reducedLightSize);
        }

        void UpdateSanLight(float sanValue)
        {
            float t = Mathf.Clamp01(sanValue / 100f);
            light2D.color = SanlightColor.Evaluate(t);
        }

        private void StartLightTransition(float targetSize)
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            currentCoroutine = StartCoroutine(LerpLightSize(targetSize));
        }

        private IEnumerator LerpLightSize(float targetSize)
        {
            float startSize = light2D.pointLightInnerRadius;
            float elapsedTime = 0f;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                light2D.pointLightInnerRadius = Mathf.Lerp(startSize, targetSize, elapsedTime / transitionDuration);
                yield return null;
            }

            light2D.pointLightInnerRadius = targetSize;
        }
    }
}
