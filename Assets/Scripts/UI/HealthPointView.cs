using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthPointView : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}