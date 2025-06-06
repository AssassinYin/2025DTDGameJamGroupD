﻿using UnityEngine;
using UnityEngine.Events;
using ZhengHua;

namespace ZhXun
{
    public class GameOverManager : MonoBehaviour
    {
        public static GameOverManager Instance { get; private set; }
        public UnityEvent OnGameOver;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void GameOver()
        {
            Debug.Log("遊戲結束！");
            OnGameOver.Invoke();
        }
    }
}
