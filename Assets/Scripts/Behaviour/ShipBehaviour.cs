using UnityEngine;
using UnityEngine.Events;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent<Vector2> Move;
    [SerializeField]
    protected UnityEvent Stop;
    [SerializeField]
    protected UnityEvent Shoot;
}