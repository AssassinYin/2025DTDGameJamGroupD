using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IfButtonDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Button button;
    [SerializeField] Animator Anim;

    private void Start()
    {
        Anim.SetBool("ButtonDown", false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Anim.SetBool("ButtonDown", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Anim.SetBool("ButtonDown", false);
    }
}