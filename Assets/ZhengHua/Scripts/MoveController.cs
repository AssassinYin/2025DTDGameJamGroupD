using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Data;

namespace ZhengHua
{
    public class MoveController : MonoBehaviour
    {
        /// <summary>
        /// 移動結束事件
        /// </summary>
        public UnityEvent onMoveEnd;

        private Rigidbody2D rb;
        private bool isMoving = false;
        private bool isTurnAround = false;
        private Vector3 targetRotation;
        private UnityEvent turnAroundEnd;

        private float stopTimer = 0f;

        /// <summary>
        /// 轉身速度
        /// </summary>
        [SerializeField]
        private float rotationSpeed = 10f;
        /// <summary>
        /// 最高移動速度
        /// </summary>
        [SerializeField]
        private float maxMoveSpeed = 2f;

        private void Awake()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    Debug.LogWarning("請先加入Rigidbody2D元件");
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
                    // 轉身完後進行移動
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
                    onMoveEnd?.Invoke();
                }
            }
        }

        private void FixedUpdate()
        {
            if (isMoving && !isTurnAround)
            {
                // 維持移動速度
                if(Mathf.Abs(rb.linearVelocityX) > maxMoveSpeed)
                {
                    rb.linearVelocity = new Vector2(this.transform.right.x * maxMoveSpeed, rb.linearVelocity.y);
                }
                else
                {
                    rb.AddForce(this.transform.right * unitForce);
                }

                // 卡點檢查
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
        /// <summary>
        /// 移動推力，可以控制移動加速度
        /// </summary>
        [SerializeField]
        private float unitForce;
        /// <summary>
        /// 往前移動幾格
        /// </summary>
        /// <param name="movementPoints"></param>
        public void Move(int movementPoints = 0)
        {
            if (isMoving)
                return;
            if (movementPoints == 0)
            {
                Debug.LogWarning("請輸入移動格數");
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
        /// 施加移動推力
        /// </summary>
        private void AddMoveForce()
        {
            rb.AddForce(this.transform.right * unitForce);
            turnAroundEnd.RemoveListener(AddMoveForce);
        }

        private int hightPoints;
        /// <summary>
        /// 施加跳躍推力
        /// </summary>
        private void AddJumpForce()
        {
            rb.AddForce(this.transform.up * GetJumpForce(hightPoints));
            turnAroundEnd.RemoveListener(AddJumpForce);
        }

        /// <summary>
        /// 轉身
        /// </summary>
        private void TurnAround()
        {
            targetRotation = this.transform.rotation.eulerAngles + new Vector3(0, 180, 0);
            isTurnAround = true;
        }

        /// <summary>
        /// 跳躍
        /// </summary>
        /// <param name="heightPoints">跳幾格高</param>
        public void Jump(int heightPoints = 0)
        {
            // 未指定往前移動幾格，預設往前移動跳躍高度的兩倍
            Jump(heightPoints, heightPoints * 2);
        }

        /// <summary>
        /// 跳躍
        /// </summary>
        /// <param name="heightPoints">跳幾格高</param>
        /// <param name="movementPoint">往前幾格</param>
        public void Jump(int heightPoints = 0, int movementPoint = 0)
        {
            if (heightPoints <= 0)
                return;
            if (isMoving)
                return;
            stopTimer = 0f;
            hightPoints = heightPoints;
            turnAroundEnd.AddListener(AddJumpForce);
            Move(movementPoint);
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
                    return 0f;
            }
        }

        /// <summary>
        /// 發生卡點
        /// </summary>
        private void ForceStop()
        {
            isMoving = false;
            stopTimer = 0f;
            this.transform.position = new Vector3(Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(this.transform.position.y), Mathf.RoundToInt(this.transform.position.z));
            onMoveEnd?.Invoke();
        }

        /// <summary>
        /// 往左右瞬移
        /// </summary>
        /// <param name="position">預計要移動的位置(相對座標)</param>
        public void TeleportX(int lehgth = 1)
        {
            Teleport(new Vector2(lehgth, 0));
        }

        /// <summary>
        /// 往上下瞬移
        /// </summary>
        /// <param name="position">預計要移動的位置(相對座標)</param>
        public void TeleportY(int lehgth = 1)
        {
            Teleport(new Vector2(0, lehgth));
        }

        /// <summary>
        /// 瞬間移動
        /// </summary>
        /// <param name="position">預計要移動的位置(相對座標)</param>
        public void Teleport(Vector2 position)
        {
            turnAroundEnd.AddListener(TeleportExcute);
            teleportTarget = this.transform.position + new Vector3(position.x, position.y, 0);
            if (position.x < 0)
            {
                TurnAround();
            }
            else
            {
                turnAroundEnd?.Invoke();
            }
        }

        private Vector3 teleportTarget;

        private void TeleportExcute()
        {
            turnAroundEnd.RemoveListener(TeleportExcute);
            this.transform.position = teleportTarget;
        }
    }
}