using System;
using UnityEngine;
using UnityEngine.Events;

public class ShipHull : MonoBehaviour, IDamagable
{
    public UnityEvent<int> OnTakeDamage;
    public UnityEvent OnDestroyed;

    [SerializeField]
    private int hullStrength;
    private int currenStrength;

    private void Start() {
        currenStrength = hullStrength;
    }

    public void TakeDamage(int amount) {
        OnTakeDamage?.Invoke(Math.Min(amount, currenStrength));
        currenStrength -= amount;
        if (currenStrength <= 0) {
            OnDestroyed?.Invoke();
        }
    }
}