using UnityEngine;
using UnityEngine.Pool;

public class BulletHolder : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _instancePoint;
    [SerializeField] private float _offsetX;

    private ObjectPool<Bullet> _bulletPool;
    private int _maxPoolSize;
    private int _defaultPoolSize;

    private void Start()
    {
        _maxPoolSize = 20;
        _defaultPoolSize = 10;

        _bulletPool = new ObjectPool<Bullet>
            (
                createFunc: InstantiateBullet,
                actionOnGet: OnGetBullet,
                actionOnRelease: OnRealizeBullet,
                actionOnDestroy: (bullet) => Destroy (bullet.gameObject),
                collectionCheck: false,
                defaultCapacity: _defaultPoolSize,
                maxSize: _maxPoolSize
            );
    }

    public Bullet GetBullet()
    {
        Bullet bullet = _bulletPool.Get();
        return bullet;
    }

    private Bullet InstantiateBullet() => Instantiate (_bulletPrefab);

    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        Vector3 position = _instancePoint.transform.position;
        position.x += _offsetX;
        bullet.transform.position = position;
        bullet.transform.rotation = _instancePoint.transform.rotation;
    }

    private void OnRealizeBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}