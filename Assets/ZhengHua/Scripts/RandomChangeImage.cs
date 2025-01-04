using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Data;

namespace ZhengHua
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class RandomChangeImage : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            if(sprites != null && sprites.Length > 0)
            {
                spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            }
        }
    }
}