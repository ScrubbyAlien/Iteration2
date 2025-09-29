using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyFactory", menuName = "Enemy Factory")]
public class EnemyFactory : Factory<IEnemy>
{
    public override IEnemy GetProduct() {
        return pool.Get() as IEnemy;
    }

    private void OnEnable() {
        CreateObjectPool();
    }
}