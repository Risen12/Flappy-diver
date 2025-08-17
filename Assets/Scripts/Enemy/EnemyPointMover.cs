using System;
using System.Collections;
using UnityEngine;

public class EnemyPointMover : MonoBehaviour
{
    private Transform _point;
    private float _delta; 

    public event Action IsOnPlace;

    private void Start()
    {
        _delta = 10f;
    }

    public void SetPoint(Transform point)
    {
        _point = point;
        StartCoroutine(GoToPoint());
    }

    private IEnumerator GoToPoint()
    {
        while (transform.position != _point.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point.position, _delta);

            yield return null;
        }
    }
}