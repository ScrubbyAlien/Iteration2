using UnityEngine;
using UnityEngine.Events;
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

    public UnityEvent allEnemiesDestroyed;

    private int spawnedEnemies;
    private int enemiesLeft;
    private float spawnStartTime;

    private void OnValidate() {
        if (minXSpawnPosition > maxXSpawnPosition) maxXSpawnPosition = minXSpawnPosition;
    }

    private void Start() {
        spawnCooldown = new Cooldown(secondsPerEnemy);
        if (enabled) spawnStartTime = Time.time + spawnDelaySeconds;
    }

    private void OnEnable() {
        spawnStartTime = Time.time + spawnDelaySeconds;
    }

    void Update() {
        if (Time.time < spawnStartTime) return;
        if (!spawnCooldown.on) {
            if (limitNumber && spawnedEnemies >= enemyLimit) return;
            Enemy enemy = enemyFactory.GetProduct();
            enemy.position = new Vector2(Random.Range(minXSpawnPosition, maxXSpawnPosition), ySpawnPosition);
            spawnCooldown.Start();
            if (limitNumber) {
                spawnedEnemies++;
                enemiesLeft++;
                enemy.OnDeactivate += () => {
                    enemiesLeft--;
                    CheckEnemiesLeft();
                };
            }
        }
    }

    private void CheckEnemiesLeft() {
        if (enemiesLeft == 0 && spawnedEnemies == enemyLimit) {
            allEnemiesDestroyed?.Invoke();
        }
    }
}