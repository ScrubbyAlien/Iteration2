using UnityEngine;
using UnityEngine.Pool;

public class BasicBullet : MonoBehaviour, IBullet
{
    public Vector2 direction {
        get => transform.up;
        set => transform.up = value;
    }
    public Vector2 position {
        get => transform.position;
        set => transform.position = (Vector3)value + Vector3.forward;
    }

    public GameObject gameObjectRef => gameObject;
    public ObjectPool<IBullet> pool { get; set; }

    [SerializeField]
    private float speed, lifetime;
    private Cooldown lifetimeCooldown;

    private void Awake() {
        lifetimeCooldown = new Cooldown(lifetime);
    }

    private void Update() {
        if (gameObject.activeInHierarchy) {
            transform.Translate(direction * (speed * Time.deltaTime));
            if (!lifetimeCooldown.on) pool.Release(this);
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

    // todo: make bullets deal damage
}