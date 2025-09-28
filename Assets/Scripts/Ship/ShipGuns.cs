using UnityEngine;

public class ShipGuns : MonoBehaviour
{
    [SerializeField]
    private BulletFactory bulletFactory;
    [SerializeField, Tooltip("The number of bullets the guns can fire per second")]
    private float firingRate;
    private Cooldown firingCooldown;

    private void Awake() {
        firingCooldown = new Cooldown(1 / firingRate);
    }

    public void FireBullet() {
        if (!firingCooldown.on) {
            IBullet bullet = bulletFactory.GetBullet();
            bullet.direction = Vector2.up;

            firingCooldown.Start();
        }
    }
}