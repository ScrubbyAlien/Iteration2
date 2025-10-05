using UnityEngine;
using UnityEngine.Events;

public abstract class ShootingPattern : ScriptableObject
{
    public abstract void EvaluateIfShouldShoot(UnityEvent shoot);
}