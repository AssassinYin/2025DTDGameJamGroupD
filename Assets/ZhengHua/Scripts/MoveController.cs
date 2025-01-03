using UnityEngine;
using UnityEngine.Events;

namespace ZhengHua
{
    public class MoveController : MonoBehaviour
    {
        public UnityEvent moveEnd;
        private Rigidbody2D rb;
        private bool isMoving = false;
        private bool isTurnAround = false;
        private Vector3 targetRotation;
        private UnityEvent turnAroundEnd;

        private float stopTimer = 0f;

        /// <summary>
        /// �ਭ�t��
        /// </summary>
        [SerializeField]
        private float rotationSpeed = 10f;
        /// <summary>
        /// ���ʳt��
        /// </summary>
        [SerializeField]
        private float moveSpeed = 2f;

        private void Awake()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    Debug.LogWarning("�Х��[�JRigidbody2D����");
                }
            }
            turnAroundEnd = new UnityEvent();
        }

        // Update is called once per frame
        void Update()
        {
            if (isTurnAround)
            {
                float angle = Mathf.Lerp(transform.rotation.eulerAngles.y, targetRotation.y, Time.deltaTime * rotationSpeed);
                this.transform.rotation = Quaternion.Euler(0, angle, 0);
                if (Vector3.Distance(this.transform.rotation.eulerAngles, targetRotation) < 0.1f)
                {
                    this.transform.rotation = Quaternion.Euler(0, targetRotation.y, 0);
                    isTurnAround = false;
                    // �ਭ����i�沾��
                    turnAroundEnd?.Invoke();
                }
            }

            if (isMoving && !isTurnAround)
            {
                if(Mathf.Abs(targetX - this.transform.position.x) < 0.05f)
                {
                    this.isMoving = false;
                    rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                    this.transform.position = new Vector3(targetX, this.transform.position.y, this.transform.position.z);
                }
            }
        }

        private void FixedUpdate()
        {
            if (isMoving && !isTurnAround)
            {
                // �������ʳt��
                if(Mathf.Abs(rb.linearVelocityX) > moveSpeed)
                {
                    rb.linearVelocity = new Vector2(this.transform.right.x * moveSpeed, rb.linearVelocity.y);
                }
                else
                {
                    rb.AddForce(this.transform.right * unitForce);
                }

                // �d�I�ˬd
                if(rb.linearVelocity.magnitude < 0.1f)
                {
                    stopTimer += Time.fixedDeltaTime;
                }
                else
                {
                    stopTimer = 0f;
                }

                if(stopTimer > 1f)
                {
                    ForceStop();
                }
            }
        }

        private float targetX;
        [SerializeField]
        private float unitForce;
        [SerializeField]
        private float jumpForce;
        /// <summary>
        /// ���e���ʴX��
        /// </summary>
        /// <param name="movementPoints"></param>
        public void Move(int movementPoints = 0)
        {
            if (isMoving)
                return;
            if (movementPoints == 0)
            {
                Debug.LogWarning("�п�J���ʮ��");
                return;
            }
            stopTimer = 0f;
            turnAroundEnd.AddListener(AddMoveForce);
            targetX = (this.transform.position + (this.transform.right * movementPoints)).x;
            if(movementPoints < 0)
            {
                TurnAround();
            }
            else
            {
                turnAroundEnd?.Invoke();
            }
            isMoving = true;
        }

        /// <summary>
        /// �I�[���ʱ��O
        /// </summary>
        private void AddMoveForce()
        {
            rb.AddForce(this.transform.right * unitForce);
            turnAroundEnd.RemoveListener(AddMoveForce);
        }

        private int hightPoints;
        /// <summary>
        /// �I�[���D���O
        /// </summary>
        private void AddJumpForce()
        {
            rb.AddForce(this.transform.up * GetJumpForce(hightPoints));
            turnAroundEnd.RemoveListener(AddJumpForce);
        }

        /// <summary>
        /// �ਭ
        /// </summary>
        private void TurnAround()
        {
            targetRotation = this.transform.rotation.eulerAngles + new Vector3(0, 180, 0);
            isTurnAround = true;
        }

        /// <summary>
        /// ���D
        /// </summary>
        /// <param name="heightPoints">���X�氪</param>
        public void Jump(int heightPoints = 0)
        {
            if (heightPoints <= 0)
                return;
            if (isMoving)
                return;
            stopTimer = 0f;
            hightPoints = heightPoints;
            turnAroundEnd.AddListener(AddJumpForce);
            // ���D���ʶZ���T�w�����D���� * 2
            Move(heightPoints * 2);
        }

        private float GetJumpForce(int heightPoints)
        {
            switch (heightPoints)
            {
                case 1:
                    return 230f;
                case 2:
                    return 330f;
                default:
                    return jumpForce;
            }
        }

        /// <summary>
        /// �o�ͥd�I
        /// </summary>
        private void ForceStop()
        {
            isMoving = false;
            stopTimer = 0f;
            this.transform.position = new Vector3(Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(this.transform.position.y), Mathf.RoundToInt(this.transform.position.z));
        }
    }
}