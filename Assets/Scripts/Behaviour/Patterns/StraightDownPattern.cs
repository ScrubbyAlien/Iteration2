using UnityEngine;

[CreateAssetMenu(fileName = "StraightDown", menuName = "Patterns/Movement/StraightDown")]
public class StraightDownPattern : MovementPattern
{
    /// <inheritdoc />
    public override bool GetNextDirection(Enemy caller, out Vector2 direction) {
        direction = Vector2.down;
        return true;
    }

    /// <inheritdoc />
    public override MovementPattern Copy(Vector2 _) {
        return ScriptableObject.CreateInstance<StraightDownPattern>();
    }
}