using UnityEngine;
using System.Linq;

namespace ZhXun
{
    [CreateAssetMenu(fileName = "NecronomiconCard", menuName = "ScriptableObjects/CardEffects/NecronomiconCard", order = 7)]
    public class NecronomiconCard : CardEffect
    {
        GameObject[] enemies;
        Transform playerTf;
        [SerializeField] float roundEndDelay = 3;

        public override void Execute()
        {
            CardSystem cardSystem = Transform.FindFirstObjectByType<CardSystem>();
            cardSystem.RoundEnd(roundEndDelay);

            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                Debug.Log("沒有找到任何敵人");
                return;
            }

            playerTf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            Transform nearestEnemy = FindClosestEnemy().GetComponent<Transform>();

            Vector3 temp = playerTf.position;

            playerTf.position = nearestEnemy.position;
            nearestEnemy.position = temp;  
        }

        GameObject FindClosestEnemy()
        {
            if (enemies.Length == 0) return null;

            return enemies.OrderBy(e => Vector3.Distance(playerTf.position, e.transform.position)).FirstOrDefault();
        }
    }
}
