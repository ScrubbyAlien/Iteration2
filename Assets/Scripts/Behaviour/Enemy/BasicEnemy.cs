using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : ShipBehaviour
{
    private void Update() {
        Move?.Invoke(Vector2.down);
        Shoot?.Invoke();
    }
}