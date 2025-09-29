using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyFactory enemyFactory;

    [SerializeField, Min(0)]
    private float spawnDelaySeconds, enemiesPerSecond;
    private float secondsPerEnemy => 1 / enemiesPerSecond;
    private Cooldown spawnCooldown;

    [SerializeField]
    private float ySpawnPosition;
    [SerializeField]
    private float minXSpawnPosition, maxXSpawnPosition;

    [SerializeField]
    private bool limitNumber;
    [SerializeField, Min(0)]
    private int enemyLimit;

    private void OnValidate() {
        if (minXSpawnPosition > maxXSpawnPosition) maxXSpawnPosition = minXSpawnPosition;
    }

    private void Start() {
        spawnCooldown = new Cooldown(secondsPerEnemy);
    }

    void Update() {
        if (Time.time < spawnDelaySeconds) return;
        if (!spawnCooldown.on) {
            IEnemy enemy = enemyFactory.GetProduct();
            enemy.position = new Vector2(Random.Range(minXSpawnPosition, maxXSpawnPosition), ySpawnPosition);
            spawnCooldown.Start();
        }
    }
}