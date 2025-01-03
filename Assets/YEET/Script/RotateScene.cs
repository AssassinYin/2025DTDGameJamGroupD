using System.Collections;
using UnityEngine;

namespace YEET
{
    public class RotateScene: MonoBehaviour
    {
        [SerializeField] Camera mainCamera; // 主攝影機
        [SerializeField] float rotationSpeed = 90; // 旋轉速度（度/秒）
        bool isRotating = false; // 防止同時執行多個旋轉
        Vector2 defaultGravity; // 默認重力方向
        Quaternion targetRotation; // 目標旋轉角度

        void Start()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main; // 自動獲取主攝影機
            }

            // 記錄默認重力
            defaultGravity = Physics2D.gravity;

            // 初始化目標旋轉
            targetRotation = mainCamera.transform.rotation;
        }

        //可以自訂旋轉角度，但預設為轉半圈
        public void Rotate(int angle = -180)
        {
            if (!isRotating)
            {
                StartCoroutine(RotateToAngle(angle));
            }
        }

        private IEnumerator RotateToAngle(float angle)
        {
            isRotating = true;

            // 計算最終目標角度
            targetRotation *= Quaternion.Euler(0, 0, angle);

            // 計算新的重力方向
            Vector2 newGravity = Quaternion.Euler(0, 0, angle) * defaultGravity;

            // 平滑旋轉
            while (Quaternion.Angle(mainCamera.transform.rotation, targetRotation) > 0.1f)
            {
                mainCamera.transform.rotation = Quaternion.RotateTowards(
                    mainCamera.transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
                yield return null;
            }

            // 確保旋轉完全精確
            mainCamera.transform.rotation = targetRotation;

            // 更新物理重力方向
            Physics2D.gravity = newGravity;

            // 更新默認重力
            defaultGravity = Physics2D.gravity;

            isRotating = false;
        }
    }
}