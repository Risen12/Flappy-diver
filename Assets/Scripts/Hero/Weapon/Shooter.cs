using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private HeroBulletHolder _bulletHolder;

    private bool _isDelay;
    private WaitForSeconds _shootDelay;

    private void Start()
    {
        _isDelay = false;
        _shootDelay = new WaitForSeconds(_delayBetweenShots);
    }

    private void OnEnable()
    {
        _inputReader.LeftButtonMouseClicked += OnMouseClicked;
    }

    private void OnDisable()
    {
        _inputReader.LeftButtonMouseClicked -= OnMouseClicked;
    }

    private void OnMouseClicked()
    {
        if (_isDelay == false)
        {
            Bullet bullet = _bulletHolder.GetBullet();
            bullet.Prepare(_inputReader.MousePosition);

            _isDelay = true;
            StartCoroutine(MakeDelay());
        }
    }

    private IEnumerator MakeDelay()
    {
        yield return _shootDelay;
        _isDelay = false;
    }
}