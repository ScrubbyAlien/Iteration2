using System;
using UnityEngine;

public interface IFloatStat : IStat
{
    public event Action<float> OnFloatStatChange;
    public float readFloat { get; }
    public float initialFloatValue { get; }
}