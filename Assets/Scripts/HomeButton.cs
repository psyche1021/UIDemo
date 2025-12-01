using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform panel;
    public Controller controller;

    public float dragRange = 200f;
    public float dragBottom = 150f;
    public float pressTime = 0.1f;

    bool isPressed = false;
    float startY;
    float pressStartTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 pos = eventData.position;

        if (pos.y <= dragBottom)
        {
            isPressed = true;
            pressStartTime = Time.time;
            startY = pos.y;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isPressed) return;
        if (Time.time - pressStartTime < pressTime) return;

        float currentY = eventData.position.y;
        float delta = currentY - startY;

        if (delta > dragRange)
        {
            controller.ClosePanel();

            isPressed = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
