using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleLevel", menuName = "Obstacle level/Create new obstacle level", order = 52)]
public class ObstacleLevel : ScriptableObject
{
    [SerializeField] private Obstacle _upLineObstacle;
    [SerializeField] private Obstacle _middleLineObstacle;
    [SerializeField] private Obstacle _downLineObstacle;
    [SerializeField] private float _minScoreToGenerate;

    public Obstacle UpLineObstacle => _upLineObstacle;
    public Obstacle MiddleLineObstacle => _middleLineObstacle;
    public Obstacle DownLineObstacle => _downLineObstacle;
    public float MinScoreToGenerate => _minScoreToGenerate;
}