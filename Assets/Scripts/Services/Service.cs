using UnityEngine;

public abstract class Service<T> : MonoBehaviour where T : Service<T>
{
    [SerializeField]
    protected Locator<T> locator;

    protected abstract void Register();

    protected virtual void Start() {
        Register();
    }
}