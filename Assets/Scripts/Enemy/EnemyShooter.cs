using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _fireRate;

    private Transform _target;
    private ObjectPool<EnemyBullet> _bulletPool;
    private bool _isOnPlace;
    private WaitUntil _waitOnPlace;
    private WaitForSeconds _delay;

    public event Action Shooted;

    private void Start()
    {
        _isOnPlace = false;
        _waitOnPlace = new WaitUntil(() => _isOnPlace == true);
        _delay = new WaitForSeconds(_fireRate);
    }

    public void SetTarget(Transform target) => _target = target;

    private void Shoot()
    {
        Vector2 direction = _target.position - transform.position;
        direction.Normalize();

        EnemyBullet enemyBullet = _bulletPool.Get();
        enemyBullet.Prepare(direction);
    }

    private IEnumerator ShootContinuously()
    {
        yield return _waitOnPlace;

        while (true)
        {
            Shoot();

            yield return _delay;
        }
    }
}