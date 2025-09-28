using UnityEngine;
using UnityEngine.Pool;

public abstract class BulletFactory : ScriptableObject
{
    protected ObjectPool<IBullet> bulletPool;
    protected GameObject poolParent;
    protected abstract string poolName { get; }
    public abstract IBullet GetBullet();
    protected abstract IBullet PoolCreateBullet();

    protected bool collectionCheck;
    protected int defaultCapacity = 20;
    protected int maxCapacity = 100;

    protected virtual void OnEnable() {
        poolParent = FindPoolParent();
        bulletPool = new ObjectPool<IBullet>(
            PoolCreateBullet, PoolOnGet, PoolOnRelease, PoolOnDestroy,
            collectionCheck, defaultCapacity, maxCapacity
        );
    }

    private GameObject FindPoolParent() {
        if (poolParent) return poolParent;
        return GameObject.Find(poolName) ?? new GameObject(poolName);
    }

    protected virtual void PoolOnGet(IBullet bullet) {
        bullet.Activate();
        bullet.pool = bulletPool;
    }
    protected virtual void PoolOnRelease(IBullet bullet) {
        bullet.Deactivate();
        bullet.pool = null;
    }
    protected virtual void PoolOnDestroy(IBullet bullet) {
        Destroy(bullet.gameObjectRef);
    }
}