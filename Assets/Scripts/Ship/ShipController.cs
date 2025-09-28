using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private float xSpeed, ySpeed;

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
        }
        else body.linearVelocity = Vector2.zero;
    }

    public void Move(Vector2 newDirection) {
        direction = newDirection;
        moving = true;
    }

    public void Stop() {
        moving = false;
    }
}