using UnityEngine;
using UnityEngine.UI;

public class AirView : MonoBehaviour
{
    [SerializeField] private AirHolder _airHolder;

    private Slider _airSlider;

    private void Awake()
    {
        _airSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _airHolder.ValueChanged += OnAirValueChanged;
    }

    private void OnDisable()
    {
        _airHolder.ValueChanged -= OnAirValueChanged;
    }

    private void Start()
    {
        _airSlider.maxValue = _airHolder.MaxValue;
        _airSlider.minValue = _airHolder.MinValue;
        _airSlider.value = _airSlider.maxValue;
    }

    private void OnAirValueChanged(float value)
    { 
        _airSlider.value = value;
    }
}