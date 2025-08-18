using UnityEngine;

public class Obstacle : MonoBehaviour 
{
    [SerializeField] private bool _isNeedToAttendToCamera;

    public bool IsNeedToAttendToCamera => _isNeedToAttendToCamera;
}