using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour
{
    public UnityEvent<Vector2> Move;
    public UnityEvent Shoot;

    private void Update() {
        Move?.Invoke(Vector2.down);
        Shoot?.Invoke();
    }
}

