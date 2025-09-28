using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "BulletFactory", menuName = "Bullet Factory")]
public class BulletFactory : ScriptableObject
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private string poolName;
    [SerializeField]
    private bool collectionCheck = true;
    [SerializeField]
    private int defaultCapacity = 20;
    [SerializeField]
    private int maxCapacity = 100;

    private ObjectPool<IBullet> bulletPool;
    private GameObject poolParent;
    public bool poolParentExist => poolParent;

    public IBullet GetBullet() {
        return bulletPool.Get();
    }

    protected virtual void OnEnable() {
        bulletPool = new ObjectPool<IBullet>(
            PoolCreateBullet, PoolOnGet, PoolOnRelease, PoolOnDestroy,
            collectionCheck, defaultCapacity, maxCapacity
        );
    }

    public GameObject FindPoolParent() {
        if (poolParent) return poolParent;
        return GameObject.Find(poolName) ?? new GameObject(poolName);
    }

    private IBullet PoolCreateBullet() {
        FindPoolParent();
        GameObject bulletInstance = Instantiate(bulletPrefab, poolParent.transform);
        bulletInstance.SetActive(false);
        IBullet bullet = bulletInstance.GetComponent<IBullet>();
        return bullet;
    }
    private void PoolOnGet(IBullet bullet) {
        bullet.Activate();
        bullet.pool = bulletPool;
    }
    private void PoolOnRelease(IBullet bullet) {
        bullet.Deactivate();
        bullet.pool = null;
    }
    private void PoolOnDestroy(IBullet bullet) {
        Destroy(bullet.gameObjectRef);
    }
}