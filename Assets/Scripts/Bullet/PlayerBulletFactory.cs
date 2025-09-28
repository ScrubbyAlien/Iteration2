using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "PlayerBulletFactory", menuName = "Player Bullet Factory")]
public class PlayerBulletFactory : BulletFactory
{
    [SerializeField]
    private GameObject playerBulletPrefab;

    protected override string poolName => "=====PlayerBulletPool=====";

    /// <inheritdoc />
    public override IBullet GetBullet() {
        return bulletPool.Get();
    }

    /// <inheritdoc />
    protected override IBullet PoolCreateBullet() {
        GameObject bulletInstance = Instantiate(playerBulletPrefab, poolParent.transform);
        bulletInstance.SetActive(false);
        IBullet bullet = bulletInstance.GetComponent<IBullet>();
        return bullet;
    }
    /// <inheritdoc />
    protected override void PoolOnGet(IBullet bullet) {
        bullet.Activate();
        bullet.pool = bulletPool;
    }
    /// <inheritdoc />
    protected override void PoolOnRelease(IBullet bullet) {
        bullet.Deactivate();
        bullet.pool = null;
    }
    /// <inheritdoc />
    protected override void PoolOnDestroy(IBullet bullet) {
        Destroy(bullet.gameObjectRef);
    }
}