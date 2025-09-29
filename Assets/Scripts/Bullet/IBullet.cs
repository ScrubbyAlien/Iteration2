using UnityEngine;
using UnityEngine.Pool;

public interface IBullet : IPoolObject
{
    public Vector2 direction { get; set; }
    public Vector2 position { get; set; }
    // public ObjectPool<IBullet> pool { get; set; }

    protected static bool LayerAffected(LayerMask affected, int layer) {
        return affected == (affected | (1 << layer));
    }
}