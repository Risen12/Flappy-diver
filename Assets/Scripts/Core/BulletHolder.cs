using UnityEngine;
using UnityEngine.Pool;

public class BulletHolder<T> : MonoBehaviour where T : Bullet
{
    [SerializeField] protected T _bulletPrefab;
    [SerializeField] protected int _maxPoolSize;
    [SerializeField] protected Transform _instancePoint;

    protected ObjectPool<T> _bulletPool;

    protected void Awake()
    {
        _bulletPool = new ObjectPool<T>
            (
                createFunc: InstantiateBullet,
                actionOnGet: OnGetBullet,
                actionOnRelease: OnReleaseBullet,
                actionOnDestroy: (bullet) => Destroy(bullet.gameObject),
                collectionCheck: false,
                defaultCapacity: _maxPoolSize,
                maxSize: _maxPoolSize
            );
    }

    public T GetBullet() => _bulletPool.Get();

    protected T InstantiateBullet() => Instantiate(_bulletPrefab);

    protected virtual void OnGetBullet(T bullet)
    {
        bullet.gameObject.SetActive(true);
        Vector3 position = _instancePoint.transform.position;
        bullet.transform.position = position;
        bullet.transform.rotation = _instancePoint.transform.rotation;
    }

    protected virtual void OnReleaseBullet(T bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}