using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Health : MonoBehaviour
{
    private int _healthPoints;
    private Mover _mover;

    public event Action<int> HealthPointsChanged;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        _healthPoints = 3;
        HealthPointsChanged?.Invoke(_healthPoints);
    }

    private void OnEnable()
    {
        _mover.CollisionObstacleHappened += OnObstacleCollisionHappened;
    }

    private void OnDisable()
    {
        _mover.CollisionObstacleHappened -= OnObstacleCollisionHappened;
    }

    private void OnObstacleCollisionHappened()
    { 
        _healthPoints--;

        if (_healthPoints == 0)
        {

        }

        HealthPointsChanged?.Invoke(_healthPoints);
    }
}
