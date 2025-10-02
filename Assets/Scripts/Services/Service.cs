using UnityEngine;

public abstract class Service<T> : MonoBehaviour
{
    [SerializeField]
    protected Locator<T> locator;

    protected abstract void Register();

    protected virtual void Start() {
        Register();
    }
}