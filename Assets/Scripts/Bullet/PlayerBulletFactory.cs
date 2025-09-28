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
}