using UnityEngine;

namespace ZhengHua
{
    public class Floowe : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        // Update is called once per frame
        void Update()
        {
            if(target != null)
            {
                transform.position = target.position;
            }
        }
    }
}