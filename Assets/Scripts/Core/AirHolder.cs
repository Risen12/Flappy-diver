using System;
using UnityEngine;

public class AirHolder : Holder
{
    private float _minValue, _maxValue, _value;

    public float MaxValue => _maxValue;

    public float MinValue => _minValue;

    private void Awake()
    {
        _minValue = 0;
        _maxValue = 100;
        _value = 100;

        _lastNotifierValue = 100;
    }

    private void Update()
    {
        _value -= _valueChanger * Time.deltaTime;

        if (Math.Abs(_value - _lastNotifierValue) >= _eventFrequency)
        {
            ValueChange(_value);
            _lastNotifierValue = _value;
        }
    }
}