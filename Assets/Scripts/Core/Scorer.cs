using System;
using UnityEngine;

public class Scorer : Holder
{
    private float _score;

    private void Start()
    {
        _score = 0;
        _lastNotifierValue = 0;
    }

    private void Update()
    {
        _score += _valueChanger * Time.deltaTime;

        if (Math.Abs(_score - _lastNotifierValue) >= _eventFrequency)
        {
            ValueChange(_score);
            _lastNotifierValue = _score;
        }
    }
}