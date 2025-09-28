using UnityEngine;
using UnityEngine.Pool;

public abstract class BulletFactory : ScriptableObject
{
    protected ObjectPool<IBullet> bulletPool;
    protected GameObject poolParent;
    protected abstract string poolName { get; }
    public abstract IBullet GetBullet();
    protected abstract IBullet PoolCreateBullet();
    protected abstract void PoolOnGet(IBullet bullet);
    protected abstract void PoolOnRelease(IBullet bullet);
    protected abstract void PoolOnDestroy(IBullet bullet);

    protected bool collectionCheck;
    protected int defaultCapacity = 20;
    protected int maxCapacity = 100;

    protected virtual void OnEnable() {
        Debug.Log("enable");
        // bulletPool = new ObjectPool<IBullet>(
        //     PoolCreateBullet, PoolOnGet, PoolOnRelease, PoolOnDestroy,
        //     collectionCheck, defaultCapacity, maxCapacity
        // );
    }

    protected void OnDisable() {
        Debug.Log("disable");
        // DestroyImmediate(poolParent);
    }
}