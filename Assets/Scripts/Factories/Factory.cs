using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public abstract class Factory<T> : ScriptableObject where T : class
{
    public abstract T GetProduct();

    [SerializeField]
    protected GameObject prefab;
    [SerializeField, FormerlySerializedAs("poolName")]
    protected string sortingName;
    protected GameObject poolParent;
    [SerializeField]
    protected bool collectionCheck = true;
    [SerializeField]
    protected int defaultCapacity = 20;
    [SerializeField]
    protected int maxCapacity = 100;

    protected ObjectPool<IPoolObject> pool;

    protected virtual void CreateObjectPool() {
        pool = new ObjectPool<IPoolObject>(
            PoolCreate, PoolOnGet, PoolOnRelease, PoolOnDestroy,
            collectionCheck, defaultCapacity, maxCapacity
        );
    }

    protected void FindPoolParent() {
        poolParent = GameObject.Find(sortingName) ?? new GameObject(sortingName);
    }

    protected virtual IPoolObject PoolCreate() {
        FindPoolParent();
        GameObject instance = Instantiate(prefab, poolParent.transform);
        instance.SetActive(false);
        IPoolObject poolObject = instance.GetComponent<IPoolObject>();
        return poolObject;
    }
    protected virtual void PoolOnGet(IPoolObject poolObject) {
        poolObject.Activate();
        poolObject.pool = pool;
    }
    protected virtual void PoolOnRelease(IPoolObject poolObject) {
        poolObject.Deactivate();
        poolObject.pool = null;
    }
    protected virtual void PoolOnDestroy(IPoolObject poolObject) {
        Destroy(poolObject.gameObjectRef);
    }
}