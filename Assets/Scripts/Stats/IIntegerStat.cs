using System;
using UnityEngine;

public interface IIntegerStat : IStat
{
    public event Action<int> OnIntStatChange;
    public int readInt { get; }
    public int initialIntValue { get; }
}