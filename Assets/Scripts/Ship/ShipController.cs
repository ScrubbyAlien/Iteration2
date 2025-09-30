using System;
using UnityEngine;
using UnityEngine.Events;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private float xSpeed, ySpeed;

    [SerializeField]
    private Events events;

    private bool moving;
    private Vector2 direction;

    private void Awake() {
        body.gravityScale = 0;
    }

    private void FixedUpdate() {
        if (moving) {
            float xVelocity = direction.x * xSpeed;
            float yVelocity = direction.y * ySpeed;
            body.linearVelocity = new Vector2(xVelocity, yVelocity);

            if (yVelocity > 0) events.MovingForward?.Invoke();
            else events.Stopped?.Invoke();
            if (xVelocity > 0) events.MovingRight?.Invoke();
            else if (xVelocity < 0) events.MovingLeft?.Invoke();
            else events.GoingStraight?.Invoke();
        }
        else {
            body.linearVelocity = Vector2.zero;
            events.Stopped?.Invoke();
            events.GoingStraight?.Invoke();
        }
    }

    public void Move(Vector2 newDirection) {
        direction = newDirection;
        moving = true;
    }

    public void Stop() {
        moving = false;
    }

    [Serializable]
    public struct Events
    {
        public UnityEvent MovingForward;
        public UnityEvent Stopped;
        public UnityEvent MovingLeft;
        public UnityEvent MovingRight;
        public UnityEvent GoingStraight;
    }
}