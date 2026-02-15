using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    public Vector2 inputVector;
    // public float deflectionInput;
    // public float elevationInput;

    public float handleRange;

    public void OnPointerDown(PointerEventData eventData){
        OnDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData){
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );

        pos = Vector2.ClampMagnitude(pos, handleRange);
        handle.anchoredPosition = pos;
        inputVector = new Vector2(pos.x / handleRange, pos.y / handleRange);
    }
    public void OnPointerUp(PointerEventData eventData){
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
