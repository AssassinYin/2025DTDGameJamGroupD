using System.Collections.Generic;
using UnityEngine.Events;

namespace ZhengHua
{
    public class PlayerManager
    {
        private static PlayerManager instance;
        private static readonly object _lock = new object();
        public EndingEnum ending = EndingEnum.None;

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
            OnRoundEnd.AddListener(RoundEnd);
        }

        public void Reset()
        {
            collectionDict = new Dictionary<CollectionEnum, int>();
            invincibleTurns = 0;
        }

        private void RoundEnd()
        {
            if(invincibleTurns > 0)
            {
                invincibleTurns--;
            }
        }

        private Dictionary<CollectionEnum, int> collectionDict = new Dictionary<CollectionEnum, int>();

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

        /// <summary>
        /// 成功拾取收集品
        /// </summary>
        /// <param name="collectionEnum"></param>
        public void AddCollection(CollectionEnum collectionEnum)
        {
            if(collectionDict == null)
            {
                collectionDict = new Dictionary<CollectionEnum, int>();
            }
            if (collectionDict.ContainsKey(collectionEnum))
            {
                collectionDict[collectionEnum]++;
            }
            else
            {
                collectionDict.Add(collectionEnum, 1);
            }
        }

        public int GetCollectionCount(CollectionEnum collectionEnum)
        {
            if (collectionDict.ContainsKey(collectionEnum))
            {
                return collectionDict[collectionEnum];
            }
            return 0;
        }
    }
}