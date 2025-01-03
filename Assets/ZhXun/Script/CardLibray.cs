using System.Collections.Generic;
using UnityEngine;  

namespace ZhXun
{
    /*
    儲存卡牌的資料，包含名子、圖片、效果
    */
    [CreateAssetMenu(fileName = "CardLibray", menuName = "ScriptableObjects/Libray/CardLibray", order = 1)]
    public class CardLibray : ScriptableObject
    {
        [System.Serializable]
        public class CardBaseData
        {
            [field: SerializeField] public string Name { get; private set; }

            [Header("正面")]
            [field: SerializeField] public Sprite frontSprite { get; private set; }
            [field: SerializeField] public CardEffect frontCardEffect { get; private set; }
            [field: SerializeField, TextArea(3, 5)] public string frontDescription { get; private set; }

            [Header("背面")]
            [field: SerializeField] public Sprite backSprite { get; private set; }
            [field: SerializeField] public CardEffect backCardEffect { get; private set; }
            [field: SerializeField, TextArea(3, 5)] public string backDescription { get; private set; }

        }

        public List<CardBaseData> cardList = new List<CardBaseData>();
    }
}
