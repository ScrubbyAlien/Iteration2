using UnityEngine;
using UnityEngine.Pool;

public interface IPoolObject
{
    public ObjectPool<IPoolObject> pool { get; set; }
    public GameObject gameObjectRef { get; }
    public void Activate();
    public void Deactivate();
}