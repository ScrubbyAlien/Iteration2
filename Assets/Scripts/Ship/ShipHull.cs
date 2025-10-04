using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShipHull : MonoBehaviour, IDamagable, IIntegerStat
{
    public string statId => "shiphull";
    public event Action<int> OnStatChange;
    public int read => currentStrength;
    public int initialValue => hullStrength;

    [SerializeField]
    private ExplosionLocator explosionLocator;

    [SerializeField]
    private ExplosionService.ExplosionParameters explosionParameters;

    [SerializeField]
    private int hullStrength;
    private int _cs;
    private int currentStrength {
        get => _cs;
        set {
            _cs = value;
            OnStatChange?.Invoke(value);
        }
    }

    [SerializeField]
    private float invincibilityTime;
    private Cooldown invincibilityCooldown;

    public UnityEvent<int> OnTakeDamage;
    public UnityEvent OnDestroyed;
    public UnityEvent OnExploded;

    private void Start() {
        currentStrength = hullStrength;
        invincibilityCooldown = new Cooldown(invincibilityTime);
    }

    public void TakeDamage(int amount) {
        OnTakeDamage?.Invoke(Math.Min(amount, currentStrength));
        invincibilityCooldown.Start();
        currentStrength -= amount;
        if (currentStrength <= 0) {
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