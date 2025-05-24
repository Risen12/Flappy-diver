using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceJumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpButtonPressed += OnJumpedButtonPressed;
    }

    private void OnDisable()
    {
        _inputReader.JumpButtonPressed -= OnJumpedButtonPressed;
    }

    private void OnJumpedButtonPressed()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
