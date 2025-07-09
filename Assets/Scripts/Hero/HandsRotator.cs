using UnityEngine;

public class HandsRotator : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.MousePositionChanged += OnMousePositionChanged;
    }

    private void OnDisable()
    {
        _inputReader.MousePositionChanged -= OnMousePositionChanged;
    }

    private void OnMousePositionChanged(Vector2 mousePosition)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = mousePosition - currentPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}