using UnityEngine;

public abstract class MovementPattern : ScriptableObject
{
    public abstract bool GetNextDirection(GameObject caller, out Vector2 direction);
}