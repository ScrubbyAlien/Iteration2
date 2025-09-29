using UnityEngine;

public interface IEnemy : IPoolObject
{
    public Vector2 position { get; set; }
}