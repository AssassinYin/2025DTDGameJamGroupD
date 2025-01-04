using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 玩家角色
    public float smoothSpeed = 5f;  // 攝影機平滑移動速度
    public Vector3 offset;  // 位移（可用於調整攝影機位置）

    void FixedUpdate()
    {
        if (target == null) return;

        // 計算目標位置
        Vector3 targetPosition = target.position + offset;

        // 平滑移動攝影機
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
