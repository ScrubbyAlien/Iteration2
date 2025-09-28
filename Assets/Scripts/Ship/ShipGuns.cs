using UnityEngine;

public class ShipGuns : MonoBehaviour
{
    [SerializeField]
    private BulletFactory bulletFactory;
    [SerializeField, ExposeFields]
    private GunConfiguration gunConfig;
    [SerializeField, Tooltip("The number of bullets the guns can fire per second")]
    private float firingRate;
    private Cooldown firingCooldown;

    private void Awake() {
        firingCooldown = new Cooldown(1 / firingRate);
    }

    public void FireBullet() {
        if (!firingCooldown.on) {
            foreach (GunInfo gunInfo in gunConfig.guns) {
                IBullet bullet = bulletFactory.GetBullet();
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