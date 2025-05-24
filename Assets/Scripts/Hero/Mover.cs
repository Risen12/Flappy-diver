using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _velocity;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_direction * _speed);
        _rigidbody.linearVelocity = _velocity;
    }
}
