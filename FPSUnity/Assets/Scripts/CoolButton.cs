using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CoolButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onPointerDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void OnMouseOver()
    {
        print("OnMouseOver");
    }
}
