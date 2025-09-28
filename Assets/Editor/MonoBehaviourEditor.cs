using UnityEditor;
using UnityEngine;

//https://discussions.unity.com/t/editor-tool-better-scriptableobject-inspector-editing/671671
[CustomEditor(typeof(MonoBehaviour), true)]
public class MonoBehaviourEditor : Editor { }