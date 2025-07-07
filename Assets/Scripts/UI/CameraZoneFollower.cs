using UnityEngine;

public class CameraZoneFollower : MonoBehaviour
{
    private float _currenyPositionY;

    private void Start()
    {
        _currenyPositionY = transform.position.y;
    }

    private void FixedUpdate()
    {
        Vector3 position = new Vector3(transform.position.x, _currenyPositionY, transform.position.z);

        transform.position = position;
    }
}