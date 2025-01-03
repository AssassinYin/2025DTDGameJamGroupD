using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZhXun
{
    /*
    卡牌在UI的顯示以及動畫
    */
    public class CardUI : MonoBehaviour
    {
        [SerializeField] GameObject[] cardUI;
        RectTransform[] cardUIRectTransform = new RectTransform[3];
        Image[] cardUIImage = new Image[3];

        [SerializeField] int cardStartPos = -300;

        [Header("洗牌動畫設定")]
        [SerializeField] AnimationCurve updateHandCardsCurve;
        [SerializeField] float updateHandCardsDuration;
        [SerializeField] float handCardInterval;

        [Header("出牌動畫設定")]
        [SerializeField] AnimationCurve playCardCurve;
        [SerializeField] AnimationCurve discardCardCurve;
        [SerializeField] float playCardDuration;

        [Header("選牌動畫設定")]
        [SerializeField] float notSelectedSize;
        [SerializeField] float selectedSize;

        [Header("翻牌動畫設定")]
        [SerializeField] AnimationCurve turnFirstCardCurve;
        [SerializeField] AnimationCurve turnSecondCardCurve;
        [SerializeField] float turnCardDuration;

        [Header("")]
        [SerializeField] CardLibray cardLibray;

        void Awake()
        {
            for (int i = 0; i < 3; i++)
            {
                cardUIRectTransform[i] = cardUI[i].GetComponent<RectTransform>();
                cardUIImage[i] = cardUI[i].GetComponent<Image>();
            }
        }

        //洗牌的動畫
        public void UpdateHandCardsF(int[] handCard)
        {
            foreach (var rt in cardUIRectTransform)
            {
                rt.localPosition = new Vector3(rt.localPosition.x , cardStartPos, 0);
            }

            StartCoroutine(UpdateHandCards(handCard));
        }
        IEnumerator UpdateHandCards(int[] handCard)
        {
            for (int i = 0; i < 3; ++i)
            {
                cardUIImage[i].sprite = cardLibray.cardList[handCard[i]].frontSprite;
                cardUIRectTransform[i].localPosition
                    = new Vector2(cardUIRectTransform[i].localPosition.x, updateHandCardsCurve.Evaluate(0));

                StartCoroutine(UpdateHandCard(i));

                yield return new WaitForSeconds(handCardInterval);
            }
        }

        IEnumerator UpdateHandCard(int index)
        {
            for (float t = 0; t <= updateHandCardsDuration; t += Time.deltaTime)
            {
                float offset = 0;

                if (index == 1)
                    offset = 5;

                cardUIRectTransform[index].localPosition =
                    new Vector2(cardUIRectTransform[index].localPosition.x, updateHandCardsCurve.Evaluate(t / updateHandCardsDuration) + offset);

                yield return null;
            }
        }


        //出牌的動畫
        public void PlayCardAnimationF(int index)
        {
            StartCoroutine(PlayCardAnimation(index));
        }
        public IEnumerator PlayCardAnimation(int index)
        {
            for (float t = 0; t <= playCardDuration; t += Time.deltaTime)
            {
                for (int i = 0; i < 3; ++i)
                {
                    float offset = 0;

                    if (i == 1)
                        offset = 5;

                    if (i == index) //打出的牌
                    {
                        cardUIRectTransform[i].localPosition =
                            new Vector2(cardUIRectTransform[i].localPosition.x, playCardCurve.Evaluate(t / playCardDuration) + offset);
                    }
                    else
                    {
                        cardUIRectTransform[i].localPosition =
                            new Vector2(cardUIRectTransform[i].localPosition.x, discardCardCurve.Evaluate(t / playCardDuration) + offset);
                    }

                }

                yield return null;
            }
        }

        //選牌的動畫
        public void SelectCardAnimationF(int index)
        {
            for (int i = 0; i < 3; i++)
            {
                cardUIRectTransform[i].localScale = new Vector3(notSelectedSize, notSelectedSize, 1);
            }

            StartCoroutine(SelectCardAnimation(index));
        }

        public IEnumerator SelectCardAnimation(int index)
        {
            yield return null;

            cardUIRectTransform[index].localScale = new Vector3(selectedSize, selectedSize, 1);
        }

        //翻牌動畫
        public void TurnCardAnimationF(int handCardIndex, int cardID, bool isFront)
        {
            StartCoroutine(TurnCardAnimation(handCardIndex , cardID , isFront));
        }

        public IEnumerator TurnCardAnimation(int handCardIndex, int cardID, bool isFront)
        {
            if (isFront)
            {
                for (float t = 0; t <= turnCardDuration ; t += Time.deltaTime)
                {
                    cardUIRectTransform[handCardIndex].rotation  = Quaternion.Euler(0, turnFirstCardCurve.Evaluate(t / turnCardDuration), 0);
                    yield return null;
                }

                cardUIImage[handCardIndex].sprite = cardLibray.cardList[cardID].backSprite;

                for (float t = 0; t <= turnCardDuration; t += Time.deltaTime)
                {
                    cardUIRectTransform[handCardIndex].rotation = Quaternion.Euler(0, turnSecondCardCurve.Evaluate(t / turnCardDuration), 0);
                    yield return null;
                }

                cardUIRectTransform[handCardIndex].rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                for (float t = 0; t <= turnCardDuration; t += Time.deltaTime)
                {
                    cardUIRectTransform[handCardIndex].rotation = Quaternion.Euler(0, turnFirstCardCurve.Evaluate(t / turnCardDuration), 0);
                    yield return null;
                }

                cardUIImage[handCardIndex].sprite = cardLibray.cardList[cardID].frontSprite;

                for (float t = 0; t <= turnCardDuration; t += Time.deltaTime)
                {
                    cardUIRectTransform[handCardIndex].rotation = Quaternion.Euler(0, turnSecondCardCurve.Evaluate(t / turnCardDuration), 0);
                    yield return null;
                }

                cardUIRectTransform[handCardIndex].rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
