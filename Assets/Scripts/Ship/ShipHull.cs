using System;
using UnityEngine;
using UnityEngine.Events;

public class ShipHull : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int hullStrength;
    private int currenStrength;

    public UnityEvent<int> OnTakeDamage;
    public UnityEvent OnDestroyed;

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