using UnityEngine;

public class CrosshairHolder : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void LateUpdate()
    {
        Vector3 mousePosition = _inputReader.MousePosition;
        mousePosition.z = 0;
        transform.position = mousePosition;
    }
}