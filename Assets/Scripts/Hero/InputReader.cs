using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpButtonPressed;

    public void OnJump()
    {
        JumpButtonPressed?.Invoke();
    }
}
