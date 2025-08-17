using UnityEngine;

public class Enemy : Obstacle
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Destroy(gameObject);
        }
    }
}