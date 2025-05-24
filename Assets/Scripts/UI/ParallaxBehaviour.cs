using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _parallaxEffectStrength;

    private float _tileSize;
    private SpriteRenderer _spriteRenderer;
    private float _startPositionX;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _tileSize = _spriteRenderer.sprite.textureRect.width / _spriteRenderer.sprite.pixelsPerUnit;
        _startPositionX = transform.position.x;
    }

    private void Update()
    {
        float distance = _camera.position.x * _parallaxEffectStrength;
        float movement = _camera.position.x * (1 - _parallaxEffectStrength);

        if (movement > _startPositionX + _tileSize)
        {
            float offset = movement - (_startPositionX + _tileSize);
            _startPositionX += (_tileSize * 2);
        }
        else
        {
            Vector3 newPosition = new Vector3(_startPositionX + distance, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}