using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _parallaxEffectStrength;
    [SerializeField] private SpriteRenderer[] _sprites;

    private Vector3 _cameraPreviousPosition;
    private float _tileSize;
    private Queue<SpriteRenderer> _spritesQueue;

    private void Start()
    {
        _cameraPreviousPosition = _camera.transform.position;
        _tileSize = _sprites.FirstOrDefault().bounds.size.x -1f;
        _spritesQueue = new Queue<SpriteRenderer>(_sprites);
    }

    private void FixedUpdate()
    {
        Vector3 delta = _camera.transform.position - _cameraPreviousPosition;
        delta.y = 0f;
        float rightBound = GetRightBound();
        float cameraRightBound = GetCameraRightBound(); 

        if (cameraRightBound >= rightBound)
        {
            ChangeSprite();
        }

        _cameraPreviousPosition = _camera.transform.position;

        transform.position += delta * _parallaxEffectStrength;
    }

    private void ChangeSprite()
    {
        SpriteRenderer leftSprite = _spritesQueue.Dequeue();
        SpriteRenderer centerSprite = _spritesQueue.Peek();

        float newPositionX = _spritesQueue.Last().transform.position.x + _tileSize;

        leftSprite.transform.position = new Vector3(newPositionX, leftSprite.transform.position.y, leftSprite.transform.position.z);

        _spritesQueue.Enqueue(leftSprite);
    }

    private float GetRightBound()
    {
        SpriteRenderer rightSprite = _spritesQueue.Last();

        float rightPosition = rightSprite.transform.position.x - (_tileSize / 2);
        return rightPosition;
    }

    private float GetCameraRightBound()
    {
        float cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
        float rightBound = _camera.transform.position.x + cameraHalfWidth;

        return rightBound;
    }
}