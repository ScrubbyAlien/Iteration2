using UnityEngine;
using UnityEngine.Pool;

public class Enemy : ShipBehaviour, IPoolObject
{
    [SerializeField]
    private MovementPattern movementPattern;
    [SerializeField]
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

    private void Update() {
        if (movementPattern.GetNextDirection(gameObject, out Vector2 direction)) Move?.Invoke(direction);
        else Stop?.Invoke();

        shootingPattern.EvaluateIfShouldShoot(Shoot);

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
        foreach (Behaviour component in GetComponents<Behaviour>()) {
            component.enabled = true;
        }
    }
    public void Deactivate() {
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
            other.gameObject.GetComponent<IDamagable>().TakeDamage(contactDamage);
        }
    }
}