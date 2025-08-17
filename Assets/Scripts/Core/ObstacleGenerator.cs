using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private EasyObstacleLevel[] _easyObstacleLevels;
    [SerializeField] private MediumObstacleLevel[] _mediumObstacleLevels;
    [SerializeField] private HardObstacleLevel[] _hardObstacleLevels;
    [SerializeField] private float _minimumDelayBetweenGenerate;
    [SerializeField] private float _maximumDelayBetweenGenerate;
    [SerializeField] private Scorer _scorer;

    private WaitForSeconds _delayBetweenGenerate;

    private void Start()
    {
        StartCoroutine(StartGenerate());
    }

    private IEnumerator StartGenerate()
    {
        while (true)
        {
            SetDelay();

            yield return _delayBetweenGenerate;

            Generate();
        }
    }

    private void Generate()
    {
        
    }

    private void SetDelay()
    {
        float delay = UserUtils.GetRandomNumber(_minimumDelayBetweenGenerate, _maximumDelayBetweenGenerate);
        _delayBetweenGenerate = new WaitForSeconds(delay);
    }
}