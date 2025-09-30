using UnityEngine;

public interface IDamagable
{
    public void TakeDamage(int amount);
    public bool invincible { get; }
}