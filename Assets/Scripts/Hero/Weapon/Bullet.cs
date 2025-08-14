using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected bool _isCollide;
    protected Rigidbody2D _rigidbody;

    private void Awake()
    {
        _isCollide = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Prepare(Vector2 direction)
    {
        _rigidbody.linearVelocity = transform.right * _speed;
        StartCoroutine(Shoot(direction));
    }

    private IEnumerator Shoot(Vector2 direction)
    {
        while (_isCollide == false)
        {
            yield return null;
        }
    }
}