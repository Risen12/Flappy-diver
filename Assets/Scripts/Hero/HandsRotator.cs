using UnityEngine;

public class HandsRotator : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;
    [SerializeField] private InputReader _inputReader;

    private void LateUpdate()
    {
        Vector2 mouseWorldPosition = _inputReader.MousePosition;
        Vector2 direction = mouseWorldPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, _minAngle, _maxAngle);

        transform.rotation = Quaternion.Euler(0,0, clampedAngle);
    }
}