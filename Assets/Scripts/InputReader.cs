using System;
using UnityEngine;


public class InputReader : MonoBehaviour
{
    private KeyCode _jumpKey;
    private Vector3 _mousePosition;

    public Vector3 MousePosition => _mousePosition;

    public event Action JumpButtonPressed;
    public event Action LeftButtonMouseClicked;

    private void Start()
    {
        _jumpKey = KeyCode.Space;
        _mousePosition = Vector3.zero;  
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LeftButtonMouseClicked?.Invoke();
        }

        Vector3 currentMousePosition = Input.mousePosition;
        currentMousePosition.z = Math.Abs(Camera.main.transform.position.z);
        _mousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
    }
}