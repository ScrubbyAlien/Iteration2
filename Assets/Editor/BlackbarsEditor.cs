using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Blackbars))]
public class BlackbarsEditor : MonoBehaviourEditor
{
    private Blackbars bars;
    private SerializedProperty width;

    private void OnEnable() {
        bars = target as Blackbars;
        width = serializedObject.FindProperty("corridorWidth");
    }

    /// <inheritdoc />
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        bars.SetCorridorWidth(width.floatValue);
    }
}