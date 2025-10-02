using UnityEngine;
using UnityEngine.Events;

public class ShipGuns : MonoBehaviour
{
    [SerializeField]
    private BulletFactory bulletFactory;
    [SerializeField, ExposeFields]
    private GunConfiguration gunConfig;
    [SerializeField, Tooltip("The number of bullets the guns can fire per second")]
    private float firingRate;
    private Cooldown firingCooldown;

    [Tooltip("If true OnShoot will be triggered for every bullet fired instead of once per salvo")]
    public bool triggerPerBullet;
    public UnityEvent OnShoot;

    private void Awake() {
        firingCooldown = new Cooldown(1 / firingRate);
    }

    public void FireBullet() {
        if (!enabled) return;
        if (!firingCooldown.on) {
            if (!triggerPerBullet) OnShoot?.Invoke();
            foreach (GunInfo gunInfo in gunConfig.guns) {
                if (triggerPerBullet) OnShoot?.Invoke();
                IBullet bullet = bulletFactory.GetProduct();
                bullet.direction = gunInfo.direction;
                bullet.position = transform.position + (Vector3)gunInfo.position;
            }
            firingCooldown.Start();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        if (!gunConfig) return;
        foreach (GunInfo gunInfo in gunConfig.guns) {
            Vector3 pos = transform.position + (Vector3)gunInfo.position;
            Gizmos.DrawLine(pos, pos + (Vector3)gunInfo.direction);
        }
    }
}