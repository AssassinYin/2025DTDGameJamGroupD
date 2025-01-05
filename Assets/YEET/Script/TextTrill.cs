using UnityEngine;
using UnityEngine.UI;

public class TextThrill : MonoBehaviour
{
    [SerializeField] Text targetText; // 目標文字
    [SerializeField] float duration = 2f; // 顫抖持續時間
    [SerializeField] float maxAmplitude = 10f; // 最大顫抖幅度
    private float elapsedTime = 0f; // 已經經過的時間

    private Vector3 originalPosition; // 文字原始位置

    void Start()
    {
        if (targetText == null)
            targetText = GetComponent<Text>();

        // 紀錄文字的本地初始位置
        originalPosition = targetText.transform.localPosition;
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 計算當前幅度（隨時間增大）
            float currentAmplitude = Mathf.Lerp(0f, maxAmplitude, elapsedTime / duration);

            // 隨機生成偏移量，保持在原始位置的附近
            float offsetX = Random.Range(-1f, 1f) * currentAmplitude;
            float offsetY = Random.Range(-1f, 1f) * currentAmplitude;

            // 更新文字位置（偏移基於原始位置）
            targetText.transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);
        }
        else
        {
            // 顫抖結束，重置文字位置
            targetText.transform.localPosition = originalPosition;
        }
    }
}