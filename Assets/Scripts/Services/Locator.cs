using System;
using UnityEngine;

public abstract class Locator<T> : ScriptableObject
{
    public event Action<T> OnRegisterService;

    protected T registeredService;

    public virtual void Register(T service) {
        registeredService = service;
        OnRegisterService?.Invoke(service);
    }

    public virtual T GetService() => registeredService;
}