using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ShipGuns : MonoBehaviour
{
    [SerializeField]
    private BulletFactory bulletFactory;
    [SerializeField, ExposeFields]
    private GunConfiguration gunConfig;
    private Cooldown firingCooldown;

    [Tooltip("If true OnShoot will be triggered for every bullet fired instead of once per salvo")]
    public bool triggerPerBullet;
    public UnityEvent OnShoot;

    private int maxStagger;
    private int currentStaggerLevel;

    private void Awake() {
        firingCooldown = new Cooldown(1 / gunConfig.fireRate);
        maxStagger = gunConfig.guns.Max(g => g.stagger);
        currentStaggerLevel = 0;
    }

    public void FireBullet() {
        if (!enabled) return;
        if (!firingCooldown.on) {
            if (!triggerPerBullet) OnShoot?.Invoke();
            foreach (GunInfo gunInfo in gunConfig.guns) {
                if (gunInfo.stagger != currentStaggerLevel) continue;
                if (triggerPerBullet) OnShoot?.Invoke();
                IBullet bullet = bulletFactory.GetProduct();
                bullet.direction = gunInfo.direction;
                bullet.position = transform.position + (Vector3)gunInfo.position;
            }
            currentStaggerLevel++;
            currentStaggerLevel %= maxStagger + 1;
            firingCooldown.Start();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        if (!gunConfig) return;
        if (gunConfig.guns.Length == 0) return;
        foreach (GunInfo gunInfo in gunConfig.guns) {
            Vector3 pos = transform.position + (Vector3)gunInfo.position;
            Gizmos.DrawLine(pos, pos + (Vector3)gunInfo.direction);
        }
    }
}