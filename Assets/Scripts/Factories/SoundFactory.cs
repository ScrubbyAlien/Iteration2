using UnityEngine;

[CreateAssetMenu(fileName = "SoundFactory", menuName = "Factory/SoundFactory")]
public class SoundFactory : Factory<SoundPlayer>
{
    /// <inheritdoc />
    public override SoundPlayer GetProduct() {
        return pool.Get() as SoundPlayer;
    }

    private void OnEnable() {
        CreateObjectPool();
    }
}