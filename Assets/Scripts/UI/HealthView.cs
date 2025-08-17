using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private HealthPointView[] _healthPointViews;
    [SerializeField] private Health _health;
    [SerializeField] private Sprite _emptyHealthSprite;
    [SerializeField] private Sprite _healthSprite;

    private void OnEnable()
    {
        _health.HealthPointsChanged += OnHealthPointsChanged;
    }

    private void OnDisable()
    {
        _health.HealthPointsChanged -= OnHealthPointsChanged;
    }

    private void OnHealthPointsChanged(int points)
    {
        int fullPoints = points;

        foreach (HealthPointView healthPointView in _healthPointViews)
        {
            if (fullPoints - 1 >= 0)
            {
                healthPointView.SetSprite(_healthSprite);
                fullPoints--;
            }
            else
            {
                healthPointView.SetSprite(_emptyHealthSprite);
            }
        }
    }
}