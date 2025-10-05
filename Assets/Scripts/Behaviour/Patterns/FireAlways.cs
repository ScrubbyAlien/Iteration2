using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FireAlways", menuName = "Patterns/Shooting/FireAlways")]
public class FireAlways : ShootingPattern
{
    /// <inheritdoc />
    public override void EvaluateIfShouldShoot(UnityEvent shoot) {
        shoot?.Invoke();
    }

    /// <inheritdoc />
    public override ShootingPattern Copy() {
        return ScriptableObject.CreateInstance<FireAlways>();
    }
}