using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class BasicBullet : MonoBehaviour, IBullet
{
    public Vector2 direction { get; set; }
    public Vector2 position {
        get => transform.position;
        set => transform.position = (Vector3)value + Vector3.forward;
    }

    public GameObject gameObjectRef => gameObject;
    public ObjectPool<IPoolObject> pool { get; set; }

    [SerializeField, Min(0)]
    private float speed, lifetime;
    private Cooldown lifetimeCooldown;
    [SerializeField]
    private LayerMask affectsLayers;
    [SerializeField, Min(0)]
    private int damage;

    public UnityEvent OnHit;

    private void Awake() {
        lifetimeCooldown = new Cooldown(lifetime);
    }

    private void Update() {
        if (gameObject.activeInHierarchy) {
            transform.Translate(direction * (speed * Time.deltaTime));
            if (!lifetimeCooldown.on) pool.Release(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (IBullet.LayerAffected(affectsLayers, other.gameObject.layer)) {
            IDamagable damagable = other.GetComponent<IDamagable>();
            damagable?.TakeDamage(damage);
            OnHit?.Invoke();
            pool.Release(this);
        }
    }

    public void Activate() {
        gameObject.SetActive(true);
        lifetimeCooldown.Start();
    }
    public void Deactivate() {
        gameObject.SetActive(false);
        lifetimeCooldown.Stop();
        transform.position = Vector3.zero;
    }
}