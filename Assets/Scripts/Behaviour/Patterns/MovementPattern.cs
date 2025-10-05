using UnityEngine;

public abstract class MovementPattern : ScriptableObject
{
    public abstract bool GetNextDirection(Enemy caller, out Vector2 direction);
    public virtual void DrawGizmos(Transform transform) { }
    public abstract MovementPattern Copy(Vector2 position);
}