using UnityEngine;

[CreateAssetMenu(fileName = "StraightDown", menuName = "Patterns/Movement/StraightDown")]
public class StraightDownPattern : MovementPattern
{
    /// <inheritdoc />
    public override bool GetNextDirection(GameObject caller, out Vector2 direction) {
        direction = Vector2.down;
        return true;
    }
}