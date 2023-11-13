using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    [SerializeField] private float _maxClickDistance;

    public bool SwipeRight { get; set; }
    public bool SwipeLeft { get; set; }
    public bool Click { get; set; }

    private Vector2 _startPosition;
    private bool _activeTouch = false;

    void Update()
    {
        if (Input.touchCount != 1)
        {
            ResetInput();
            return;
        }

        var touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began && _activeTouch == false)
        {
            _startPosition = touch.position;
            _activeTouch = true;
            return;
        }

        if(touch.phase == TouchPhase.Ended && _activeTouch)
        {
            HandleValidTouchEnd(touch);
            _activeTouch = false;
            return;
        }

        
    }

    private void HandleValidTouchEnd(Touch touch)
    {
        var delta = touch.position - _startPosition;

        if(delta.magnitude < _maxClickDistance)
        {
            Click = true;
        }


        if(delta.x > 0)
        {
            SwipeRight = true;
        }
        else
        {
            SwipeLeft = true;
        }
    }

    private void ResetInput()
    {
        SwipeRight = false;
        SwipeLeft = false;
        Click = false;
    }
}
