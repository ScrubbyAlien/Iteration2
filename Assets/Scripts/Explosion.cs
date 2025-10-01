using UnityEngine;
using UnityEngine.Pool;

public class Explosion : MonoBehaviour, IPoolObject
{
    [SerializeField]
    private Animator animator;

    public void Dissipate() {
        if (pool != null) pool.Release(this);
        else Deactivate();
    }

    public ObjectPool<IPoolObject> pool { get; set; }
    public GameObject gameObjectRef => gameObject;
    /// <inheritdoc />
    public void Activate() {
        gameObject.SetActive(true);
        animator.Play("explosion1");
    }
    /// <inheritdoc />
    public void Deactivate() {
        gameObject.SetActive(false);
    }
}