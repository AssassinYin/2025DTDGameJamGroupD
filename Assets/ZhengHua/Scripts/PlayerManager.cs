using UnityEngine.Events;

namespace ZhengHua
{
    public class PlayerManager
    {
        private static PlayerManager instance;
        private static readonly object _lock = new object();

        public static PlayerManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new PlayerManager();
                    }
                    return instance;
                }
            }
        }

        public UnityEvent OnRoundEnd;
        private int invincibleTurns = 0;

        private PlayerManager()
        {
            OnRoundEnd = new UnityEvent();
            invincibleTurns = 0;
            OnRoundEnd.AddListener(RoundEnd);
        }

        private void RoundEnd()
        {
            if(invincibleTurns > 0)
            {
                invincibleTurns--;
            }
        }

        /// <summary>
        /// 是否為無敵狀態
        /// </summary>
        public bool IsInvinciable { get => invincibleTurns > 0; }

        /// <summary>
        /// 進入無敵狀態
        /// </summary>
        /// <param name="turns"></param>
        public void EnterInvincible(int turns = 2)
        {
            invincibleTurns = turns;
        }
    }
}