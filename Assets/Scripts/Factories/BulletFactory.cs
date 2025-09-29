using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "BulletFactory", menuName = "Bullet Factory")]
public class BulletFactory : Factory<IBullet>
{
    public override IBullet GetProduct() {
        return pool.Get() as IBullet;
    }

    protected virtual void OnEnable() {
        CreateObjectPool();
    }
}