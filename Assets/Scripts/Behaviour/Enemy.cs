using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class Enemy : ShipBehaviour, IPoolObject
{
    public event Action OnDeactivate;

    [FormerlySerializedAs("movementPattern"), SerializeField, ExposeFields]
    private MovementPattern movementPatternAsset;
    private MovementPattern movementPattern;
    [FormerlySerializedAs("shootingPattern"), SerializeField, ExposeFields]
    private ShootingPattern shootingPatternAsset;
    private ShootingPattern shootingPattern;

    [SerializeField]
    private int contactDamage;
    [SerializeField]
    private ScoreLocator scoreLocator;
    [SerializeField]
    private int scoreValue;

    public ObjectPool<IPoolObject> pool { get; set; }
    public GameObject gameObjectRef => gameObject;

    public Vector2 position {
        get => transform.position;
        set => transform.position = new Vector3(value.x, value.y, transform.position.z);
    }

    private bool scoreReleased;
    private bool startedShooting;

    private void Update() {
        if (movementPattern.GetNextDirection(this, out Vector2 direction)) {
            Move?.Invoke(direction);
        }
        else Stop?.Invoke();

        if (!shootDelayCooldown.on) {
            if (!startedShooting) {
                shootingPattern.OnStartShooting();
                startedShooting = true;
            }
            shootingPattern.EvaluateIfShouldShoot(Shoot);
        }

        if (transform.position.y < yBottom) {
            Die();
        }
    }

    public override void Die() {
        if (pool != null) pool.Release(this);
        else Deactivate();
    }

    public void Activate() {
        gameObject.SetActive(true);
        scoreReleased = false;
        startedShooting = false;
        foreach (Behaviour component in GetComponents<Behaviour>()) {
            component.enabled = true;
        }
        GetComponent<ShipHull>()?.InitializeStrength();
        movementPattern = movementPatternAsset.Copy(transform.position);
        shootingPattern = shootingPatternAsset.Copy();
    }
    public void Deactivate() {
        OnDeactivate?.Invoke();
        gameObject.SetActive(false);
    }

    public void ReleaseScore() {
        if (!scoreReleased) {
            scoreLocator.GetService().GainScore(scoreValue);
            scoreReleased = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
            if (!damagable.invincible) damagable.TakeDamage(contactDamage);
        }
    }

    private void OnDrawGizmosSelected() {
        movementPatternAsset.DrawGizmos(transform);
    }
}