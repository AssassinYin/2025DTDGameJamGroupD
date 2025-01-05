using UnityEngine;
using UnityEngine.UI;

public class TextThrill : MonoBehaviour
{
    [SerializeField] Text targetText; // �ؼФ�r
    [SerializeField] float duration = 2f; // Ÿ�ݫ���ɶ�
    [SerializeField] float maxAmplitude = 10f; // �̤jŸ�ݴT��
    private float elapsedTime = 0f; // �w�g�g�L���ɶ�

    private Vector3 originalPosition; // ��r��l��m

    void Start()
    {
        if (targetText == null)
            targetText = GetComponent<Text>();

        // ������r�����a��l��m
        originalPosition = targetText.transform.localPosition;
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // �p���e�T�ס]�H�ɶ��W�j�^
            float currentAmplitude = Mathf.Lerp(0f, maxAmplitude, elapsedTime / duration);

            // �H���ͦ������q�A�O���b��l��m������
            float offsetX = Random.Range(-1f, 1f) * currentAmplitude;
            float offsetY = Random.Range(-1f, 1f) * currentAmplitude;

            // ��s��r��m�]��������l��m�^
            targetText.transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);
        }
        else
        {
            // Ÿ�ݵ����A���m��r��m
            targetText.transform.localPosition = originalPosition;
        }
    }
}