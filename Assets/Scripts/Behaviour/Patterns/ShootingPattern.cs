using UnityEngine;
using UnityEngine.Events;

public abstract class ShootingPattern : ScriptableObject
{
    public abstract void EvaluateIfShouldShoot(UnityEvent shoot);
    public abstract ShootingPattern Copy();
    public virtual void OnStartShooting() { }
}