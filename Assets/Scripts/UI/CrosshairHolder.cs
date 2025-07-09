using UnityEngine;

public class CrosshairHolder : MonoBehaviour
{
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
        transform.position = mousePosition;
    }
}