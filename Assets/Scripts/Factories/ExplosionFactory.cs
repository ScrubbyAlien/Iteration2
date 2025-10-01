using UnityEngine;

[CreateAssetMenu(fileName = "NewExplosionFactory", menuName = "Factory/Explosion Factory")]
public class ExplosionFactory : Factory<Explosion>
{
    public override Explosion GetProduct() {
        return pool.Get() as Explosion;
    }

    private void OnEnable() {
        CreateObjectPool();
    }
}