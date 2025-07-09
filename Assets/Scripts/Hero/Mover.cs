using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    public float Speed => _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_direction * _speed);

        if (_rigidbody.linearVelocity.magnitude > _maxSpeed)
        {
            _rigidbody.linearVelocity = _rigidbody.linearVelocity.normalized * _maxSpeed;
        }
    }
}