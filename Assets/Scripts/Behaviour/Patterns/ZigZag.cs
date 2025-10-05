using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZigZag", menuName = "Patterns/Movement/ZigZag")]
public class ZigZag : MovementPattern
{
    [SerializeField]
    private float width = 2;
    [SerializeField, Range(0, 90)]
    private float angle = 45;
    [SerializeField]
    private StartDirection startDirection = StartDirection.Random;
    private Vector2 currentDirection;
    private Vector2 startPosition;

    /// <inheritdoc />
    public override MovementPattern Copy(Vector2 position) {
        ZigZag copy = ScriptableObject.CreateInstance<ZigZag>();
        copy.width = width;
        copy.angle = angle;
        copy.startPosition = position;
        copy.SetStartDirection();
        return copy;
    }

    public override bool GetNextDirection(Enemy caller, out Vector2 direction) {
        if (AboutToLeaveWidth(caller)) {
            currentDirection = new Vector2(-currentDirection.x, currentDirection.y);
        }
        direction = currentDirection;
        return true;
    }

    private void SetStartDirection() {
        switch (startDirection) {
            case StartDirection.Left:
                currentDirection = AngleToVector(-angle);
                break;
            case StartDirection.Right:
                Vector2 left = AngleToVector(-angle);
                currentDirection = new Vector2(-left.x, left.y);
                break;
            case StartDirection.Random:
                if (Random.value < 0.5f) goto case StartDirection.Left;
                else goto case StartDirection.Right;
        }
    }

    private bool AboutToLeaveWidth(Enemy caller) {
        float maxX = startPosition.x + width / 2;
        float minX = startPosition.x - width / 2;
        float curX = caller.transform.position.x;
        float directionSign = Mathf.Sign(currentDirection.x);
        bool aboutToLeaveLeft = curX <= minX && directionSign < 0;
        bool aboutToLeaveRight = curX >= maxX && directionSign > 0;
        return aboutToLeaveLeft || aboutToLeaveRight;
    }

    private static Vector2 AngleToVector(float angle) {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }

    /// <inheritdoc />
    public override void DrawGizmos(Transform transform) {
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + AngleToVector(-angle));
    }

    public enum StartDirection
    {
        Right,
        Left,
        Random
    }
}