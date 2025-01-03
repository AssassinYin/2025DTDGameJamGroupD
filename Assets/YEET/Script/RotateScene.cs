using System.Collections;
using UnityEngine;

namespace YEET
{
    public class RotateScene: MonoBehaviour
    {
        [SerializeField] Camera mainCamera; // �D��v��
        [SerializeField] float rotationSpeed = 90; // ����t�ס]��/��^
        bool isRotating = false; // ����P�ɰ���h�ӱ���
        Vector2 defaultGravity; // �q�{���O��V
        Quaternion targetRotation; // �ؼб��ਤ��

        void Start()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main; // �۰�����D��v��
            }

            // �O���q�{���O
            defaultGravity = Physics2D.gravity;

            // ��l�ƥؼб���
            targetRotation = mainCamera.transform.rotation;
        }

        //�i�H�ۭq���ਤ�סA���w�]����b��
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

            // �p��̲ץؼШ���
            targetRotation *= Quaternion.Euler(0, 0, angle);

            // �p��s�����O��V
            Vector2 newGravity = Quaternion.Euler(0, 0, angle) * defaultGravity;

            // ���Ʊ���
            while (Quaternion.Angle(mainCamera.transform.rotation, targetRotation) > 0.1f)
            {
                mainCamera.transform.rotation = Quaternion.RotateTowards(
                    mainCamera.transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
                yield return null;
            }

            // �T�O���৹����T
            mainCamera.transform.rotation = targetRotation;

            // ��s���z���O��V
            Physics2D.gravity = newGravity;

            // ��s�q�{���O
            defaultGravity = Physics2D.gravity;

            isRotating = false;
        }
    }
}