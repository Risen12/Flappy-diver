using UnityEngine;

public class HeroBulletHolder : BulletHolder<Bullet>
{
    [SerializeField] private float _offsetX;

    protected void Awake()
    {
        base.Awake();
    }

    protected override void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        Vector3 position = _instancePoint.transform.position;
        position.x += _offsetX;
        bullet.transform.position = position;
        bullet.transform.rotation = _instancePoint.transform.rotation;
    }
}