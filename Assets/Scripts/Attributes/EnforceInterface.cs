using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class EnforceInterface : PropertyAttribute
{
    private readonly bool allowMultiple;
    private readonly Type interfaceType;

    public EnforceInterface(Type type, bool allowMultiple = false) {
        this.allowMultiple = allowMultiple;
        if (type.IsInterface) this.interfaceType = type;
        else Debug.LogWarning($"EnforceInterface only supports interface types, not {type.Name}");
    }

    private bool Enforce(GameObject gameObject) {
        if (allowMultiple) return gameObject.GetComponent(interfaceType);

        int length = gameObject.GetComponents(interfaceType).Length;
        if (length > 1) {
            WarnMultipleImplementations(gameObject.name);
            return false;
        }
        if (length < 1) return false;
        return true;
    }

    public bool Enforce(object o) {
        if (o is GameObject gameObject) return Enforce(gameObject);
        if (allowMultiple) return o.GetType().GetInterface(interfaceType.Name) != null;

        int length = o.GetType().GetInterfaces().Length;
        if (length > 1) {
            WarnMultipleImplementations(o.ToString());
            return false;
        }
        if (length < 1) return false;
        return true;
    }

    private void WarnMultipleImplementations(string objectName) {
        Debug.LogWarning($"{objectName} has more than one component that implements ${interfaceType.Name}, " +
                         $"Set allowMultiple to true in EnforceInterface attribute if this is intended.");
    }
}