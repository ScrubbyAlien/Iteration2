using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class BasicEnemy : ShipBehaviour, IEnemy
{
    [SerializeField]
    private ScoreLocator scoreLocator;
    [SerializeField]
    private int scoreValue;

    public ObjectPool<IPoolObject> pool { get; set; }
    public GameObject gameObjectRef => gameObject;

    /// <inheritdoc />
    public Vector2 position {
        get => transform.position;
        set => transform.position = new Vector3(value.x, value.y, transform.position.z);
    }

    private bool scoreReleased;

    private void Update() {
        Move?.Invoke(Vector2.down);
        if (!shootDelayCooldown.on) Shoot?.Invoke();

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
}