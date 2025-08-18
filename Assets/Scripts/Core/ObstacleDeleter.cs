using UnityEngine;

public class ObstacleDeleter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        { 
            Destroy(obstacle.gameObject);
        }
    }
}