using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyFactory", menuName = "Factory/Enemy Factory")]
public class EnemyFactory : Factory<Enemy>
{
    public override Enemy GetProduct() {
        return pool.Get() as Enemy;
    }

    private void OnEnable() {
        CreateObjectPool();
    }
}