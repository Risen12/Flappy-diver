using UnityEngine;

public class ObstacleLevel : ScriptableObject
{
    [SerializeField] protected float _minScoreToGenerate;
    [SerializeField] protected Obstacle _middleLineObstacle;
}