using UnityEngine;
using UnityEngine.Pool;

public interface IBullet
{
    public Vector2 direction { get; set; }
    public GameObject gameObjectRef { get; }
    public ObjectPool<IBullet> pool { get; set; }
    public void Activate();
    public void Deactivate();
}