using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private const float _minHoldingTime = 0.2f;

    [SerializeField] private Camera _mainCamera;

    private float _startTime;
    private float _holdingTime;

    public event Action<Vector2> StartedTouching;
    public event Action<Vector2> Dragged;
    public event Action<Vector2, float> EndedTouching;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _startTime = Time.time;
        StartedTouching?.Invoke(_mainCamera.ScreenToWorldPoint(pointerEventData.position));
    }    

    public void OnDrag(PointerEventData pointerEventData)
    {
        Dragged?.Invoke(_mainCamera.ScreenToWorldPoint(pointerEventData.position));
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _holdingTime = Time.time - _startTime;
        
        if(_holdingTime > _minHoldingTime)
            EndedTouching?.Invoke(_mainCamera.ScreenToWorldPoint(pointerEventData.position), _holdingTime);
    }
}
