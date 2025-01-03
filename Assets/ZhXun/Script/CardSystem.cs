using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace ZhXun
{
    /*
    用來管理卡牌系統，如抽牌、洗牌、選牌
    */
    public class CardSystem : MonoBehaviour
    {
        [System.Serializable]
        struct handCardData
        {
            public int ID;
            public bool isFornt;
        }

        [SerializeField] handCardData[] handCards;

        //資料
        [SerializeField] CardLibray cardLibray;

        //引用腳本
        [SerializeField] CardUI cardUI;

        //引用組件
        [SerializeField] Text cardDescriptionText;

        int currentSelectedCard = 0;

        void Awake()
        {
           
        }

        void Start()
        {
            Shuffle();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SelectCard(currentSelectedCard - 1) ;
            }
            if (Input.GetKeyDown(KeyCode.D)) 
            {
                SelectCard(currentSelectedCard + 1);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayCard();
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                TurnCard();
            }
        }


        //選牌
        void SelectCard(int index)
        {
            if (index > 2)
            {
                currentSelectedCard = 0;
            }
            else if (index < 0)
            {
                currentSelectedCard = 2;
            }
            else
            {
                currentSelectedCard = index;
            }

            cardUI.SelectCardAnimationF(currentSelectedCard);

            UpdateDescription();
        }

        //洗牌
        void Shuffle()
        {
            int cardCount = cardLibray.cardList.Count;

            List<int> cardListTempPool = new List<int>();

            for (int i = 0; i < cardCount; i++)
            {
                cardListTempPool.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                int randomNumber = Random.Range(0, cardListTempPool.Count);

                handCards[i].ID = cardListTempPool[randomNumber];
                cardListTempPool.RemoveAt(randomNumber);
            }

            int[] handCardsIndex = new int[3];

            for (int i = 0; i < 3; i++)
            {
                handCardsIndex[i] = handCards[i].ID;
            }

            cardUI.UpdateHandCardsF(handCardsIndex);
            SelectCard(0);

            UpdateDescription();
        }

        //出牌
        void PlayCard()
        {
            if(currentSelectedCard == -1)
            {
                return;
            }

            if (handCards[currentSelectedCard].isFornt)
            {
                //觸發正面卡牌效果
                cardLibray.cardList[handCards[currentSelectedCard].ID].frontCardEffect.Execute();
            }
            else
            {
                //觸發背面卡牌效果
                cardLibray.cardList[handCards[currentSelectedCard].ID].backCardEffect.Execute();
            }

            cardUI.PlayCardAnimationF(currentSelectedCard);
            StartCoroutine(PlayCardDelay());
        }

        IEnumerator PlayCardDelay()
        {
            //等待回合結束
            yield return new WaitForSeconds(1.5f);

            Shuffle();
        }

        //翻牌
        void TurnCard()
        {
            bool isFornt = handCards[currentSelectedCard].isFornt;
            handCards[currentSelectedCard].isFornt = !isFornt;

            cardUI.TurnCardAnimationF(currentSelectedCard , handCards[currentSelectedCard].ID , isFornt);

            UpdateDescription();
        }

        //顯示描述
        void UpdateDescription()
        {
            if (handCards[currentSelectedCard].isFornt)
            {
                cardDescriptionText.text = cardLibray.cardList[handCards[currentSelectedCard].ID].frontDescription;
            }
            else
            {
                cardDescriptionText.text = cardLibray.cardList[handCards[currentSelectedCard].ID].backDescription;
            }
        }
    }
}