using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Scorer _scorer;

    private TextMeshProUGUI _scoreView;

    private void Awake()
    {
        _scoreView = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scorer.ValueChanged += OnScoreValueChanged;
    }

    private void OnDisable()
    {
        _scorer.ValueChanged -= OnScoreValueChanged;
    }

    private void OnScoreValueChanged(float score)
    {
        _scoreView.text = score.ToString("f0");
    }
}