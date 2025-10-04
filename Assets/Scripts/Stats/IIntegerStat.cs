using System;
using UnityEngine;

public interface IIntegerStat : IStat
{
    public event Action<int> OnStatChange;
    public int read { get; }
    public int initialValue { get; }
}