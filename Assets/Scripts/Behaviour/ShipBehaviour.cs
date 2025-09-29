using UnityEngine;
using UnityEngine.Events;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField]
    protected float yBottom;
    [SerializeField]
    protected float shootDelay;
    protected Cooldown shootDelayCooldown;

    [SerializeField]
    protected UnityEvent<Vector2> Move;
    [SerializeField]
    protected UnityEvent Stop;
    [SerializeField]
    protected UnityEvent Shoot;

    protected virtual void Start() {
        shootDelayCooldown = new Cooldown(shootDelay);
        shootDelayCooldown.Start();
    }

    public virtual void Die() {
        gameObject.SetActive(false);
    }
}