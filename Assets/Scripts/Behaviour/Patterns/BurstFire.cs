using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BurstFire", menuName = "Patterns/Shooting/Burst Fire")]
public class BurstFire : ShootingPattern
{
    [SerializeField, Min(0)]
    private float burstDuration;
    [SerializeField, Min(0)]
    private float burstWait;

    private Cooldown burstingCooldown;
    private Cooldown waitCooldown;

    private State state;

    public override void EvaluateIfShouldShoot(UnityEvent shoot) {
        switch (state) {
            case State.Bursting:
                if (burstingCooldown.on) shoot?.Invoke();
                else {
                    state = State.Waiting;
                    waitCooldown.Start();
                }
                break;
            case State.Waiting:
                if (!waitCooldown.on) {
                    state = State.Bursting;
                    burstingCooldown.Start();
                }
                break;
        }
    }

    /// <inheritdoc />
    public override void OnStartShooting() {
        state = State.Bursting;
        burstingCooldown.Start();
    }

    /// <inheritdoc />
    public override ShootingPattern Copy() {
        BurstFire copy = ScriptableObject.CreateInstance<BurstFire>();
        copy.burstDuration = burstDuration;
        copy.burstWait = burstWait;
        copy.burstingCooldown = new Cooldown(burstDuration);
        copy.waitCooldown = new Cooldown(burstWait);
        return copy;
    }

    private enum State
    {
        Bursting,
        Waiting
    }
}