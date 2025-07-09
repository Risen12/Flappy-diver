using System;
using UnityEngine;


public class InputReader : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private KeyCode _jumpKey;
    private Vector2 _mousePosition;
    private float _currentMousePositionX;
    private float _currentMousePositionY;

    public event Action JumpButtonPressed;
    public event Action<Vector2> MousePositionChanged;

    private void Start()
    {
        _jumpKey = KeyCode.Space;
        _mousePosition = new Vector2(_currentMousePositionX, _currentMousePositionY);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            JumpButtonPressed?.Invoke();
        }

        _mousePosition.x = Input.mousePosition.x;
        _mousePosition.y = Input.mousePosition.y;

        if (_mousePosition.x != _currentMousePositionX || _mousePosition.y != _currentMousePositionY)
        {
            Debug.Log($"{_mousePosition.x}{_mousePosition.y}");
            _currentMousePositionX = _mousePosition.x;
            _currentMousePositionY = _mousePosition.y;
            _mousePosition = new Vector2(_currentMousePositionX, _currentMousePositionY);
            _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            MousePositionChanged?.Invoke(_mousePosition);
        }
    }
}