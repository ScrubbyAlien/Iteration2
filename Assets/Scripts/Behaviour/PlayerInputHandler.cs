using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : ShipBehaviour
{
    private bool shooting;

    private void OnMove(InputValue value) {
        Vector2 inputDirection = value.Get<Vector2>();
        if (inputDirection.sqrMagnitude > 0) {
            Move?.Invoke(inputDirection);
        }
        else {
            Stop?.Invoke();
        }
    }

    private void OnShoot(InputValue value) {
        shooting = value.isPressed;
        if (shooting) Shoot?.Invoke();
    }

    private void Update() {
        if (shooting) Shoot?.Invoke();
    }
}