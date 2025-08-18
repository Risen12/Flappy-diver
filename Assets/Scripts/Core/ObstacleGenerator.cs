using System.Collections;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private ObstacleLevel[] _obstacleLevels;
    [SerializeField] private float _minimumDelayBetweenGenerate;
    [SerializeField] private float _maximumDelayBetweenGenerate;
    [SerializeField] private Scorer _scorer;
    [SerializeField] private Transform _upLine;
    [SerializeField] private Transform _downLine;
    [SerializeField] private Transform _middleLine;

    private WaitForSeconds _delayBetweenGenerate;
    private Transform[] _lines;

    private void Start()
    {
        StartCoroutine(StartGenerate());
        _lines = new Transform[] { _upLine, _middleLine, _downLine }; 
    }

    private IEnumerator StartGenerate()
    {
        while (true)
        {
            SetDelay();

            yield return _delayBetweenGenerate;

            ObstacleLevel level = PrepareLevel();
            GenerateObstacleLevel(level);
        }
    }

    private void GenerateObstacleLevel(ObstacleLevel level)
    {
        Obstacle[] obstacles = new Obstacle[] {level.UpLineObstacle, level.MiddleLineObstacle, level.DownLineObstacle }; 

        for (int i = 0; i < _lines.Length; i++)
        {
            GenerateObstacle(_lines[i], obstacles[i]);    
        }
    }

    private void GenerateObstacle(Transform line, Obstacle obstacle)
    {
        if (obstacle == null)
            return;

        Obstacle createdObstacle = Instantiate(obstacle);
        createdObstacle.transform.position = line.transform.position;
    }

    private ObstacleLevel PrepareLevel()
    {
        ObstacleLevel[] actualLevels = _obstacleLevels.Where(level => _scorer.Score >= level.MinScoreToGenerate).ToArray();
        int index = (int)UserUtils.GetRandomNumber(0, actualLevels.Length - 1);

        return actualLevels[index];
    }

    private void SetDelay()
    {
        float delay = UserUtils.GetRandomNumber(_minimumDelayBetweenGenerate, _maximumDelayBetweenGenerate);
        _delayBetweenGenerate = new WaitForSeconds(delay);
    }
}