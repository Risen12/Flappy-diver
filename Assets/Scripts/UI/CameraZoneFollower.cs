using System.Collections;
using UnityEngine;

public class CameraZoneFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDelta;
    [SerializeField] private float _movementFrequency;

    private WaitForSeconds _movementDelay;

    private void Start()
    {
        _movementDelay = new WaitForSeconds(_movementFrequency);

        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (gameObject.activeSelf)
        {
            float positionX = Mathf.MoveTowards(transform.position.x, _target.position.x, _maxDelta);
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
            yield return _movementDelay;
        }
    }
}