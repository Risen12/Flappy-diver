using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] protected Vector2 _direction;

    protected void Update()
    {
        transform.Translate(_direction * Time.deltaTime);
    }
}