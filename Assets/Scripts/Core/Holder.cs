using System;
using UnityEngine;

public abstract class Holder : MonoBehaviour
{
    [SerializeField] protected float _eventFrequency;
    [SerializeField] protected float _valueChanger;

    protected float _lastNotifierValue;

    public event Action<float> ValueChanged;

    protected void ValueChange(float value)
    { 
        ValueChanged?.Invoke(value);
    }
}