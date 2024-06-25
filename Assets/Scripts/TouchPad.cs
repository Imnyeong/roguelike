using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 touchPos;
    public Vector2 movePos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        touchPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        movePos = eventData.position;
        GameManager.instance.character.inputVector = movePos - touchPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameManager.instance.character.inputVector = Vector2.zero;
    }
}
