using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnforceInterface))]
public class EnforceInterfaceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.PropertyField(position, property, label, true);

        EnforceInterface attr = attribute as EnforceInterface;

        if (property.objectReferenceValue == null) return;
        if (!attr.Enforce(property.objectReferenceValue)) {
            property.objectReferenceValue = null;
        }
    }
}