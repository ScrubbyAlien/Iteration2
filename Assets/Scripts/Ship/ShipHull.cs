using System;
using UnityEngine;
using UnityEngine.Events;

public class ShipHull : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int hullStrength;
    private int currenStrength;

    [SerializeField]
    private float invincibilityTime;
    private Cooldown invincibilityCooldown;

    public UnityEvent<int> OnTakeDamage;
    public UnityEvent OnDestroyed;

    private void Start() {
        currenStrength = hullStrength;
        invincibilityCooldown = new Cooldown(invincibilityTime);
    }

    public void TakeDamage(int amount) {
        OnTakeDamage?.Invoke(Math.Min(amount, currenStrength));
        invincibilityCooldown.Start();
        currenStrength -= amount;
        if (currenStrength <= 0) {
            OnDestroyed?.Invoke();
        }
    }
    /// <inheritdoc />
    public bool invincible => invincibilityCooldown.on;
}