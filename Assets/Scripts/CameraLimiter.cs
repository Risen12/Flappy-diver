using UnityEngine;

public class CameraLimiter : MonoBehaviour
{
    private float _positionY;
    private Vector3 _defaultPosition;

    private void Awake()
    {
        _positionY = transform.position.y;
    }

    private void Update()
    {
        _defaultPosition = new Vector3(transform.position.x, _positionY, transform.position.z);
        transform.SetPositionAndRotation(_defaultPosition, Quaternion.identity);
    }
}
