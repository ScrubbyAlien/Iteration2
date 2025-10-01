using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShipHull : MonoBehaviour, IDamagable
{
    [SerializeField]
    private ExplosionLocator explosionLocator;

    [SerializeField]
    private ExplosionService.ExplosionParameters explosionParameters;

    [SerializeField]
    private int hullStrength;
    private int currenStrength;

    [SerializeField]
    private float invincibilityTime;
    private Cooldown invincibilityCooldown;

    public UnityEvent<int> OnTakeDamage;
    public UnityEvent OnDestroyed;
    public UnityEvent OnExploded;

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

    public void Explode() {
        explosionLocator.GetService().PlayExplosion(transform.position, explosionParameters);
        StartCoroutine(ExplosionWait(explosionParameters.duration));
    }

    private IEnumerator ExplosionWait(float duration) {
        yield return new WaitForSeconds(duration);
        OnExploded?.Invoke();
    }

    /// <inheritdoc />
    public bool invincible => invincibilityCooldown.on;
}