using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : MonoBehaviourEditor
{
    private EnemySpawner spawner;

    private SerializedProperty enemyFactory;
    private SerializedProperty spawnDelaySeconds;
    private SerializedProperty enemiesPerSecond;
    private SerializedProperty ySpawnPosition;
    private SerializedProperty minXSpawnPosition;
    private SerializedProperty maxXSpawnPosition;
    private SerializedProperty limitNumber;
    private SerializedProperty enemyLimit;
    private SerializedProperty allEnemiesDestroyed;

    private void OnEnable() {
        spawner = target as EnemySpawner;

        enemyFactory = serializedObject.FindProperty("enemyFactory");
        spawnDelaySeconds = serializedObject.FindProperty("spawnDelaySeconds");
        enemiesPerSecond = serializedObject.FindProperty("enemiesPerSecond");
        ySpawnPosition = serializedObject.FindProperty("ySpawnPosition");
        minXSpawnPosition = serializedObject.FindProperty("minXSpawnPosition");
        maxXSpawnPosition = serializedObject.FindProperty("maxXSpawnPosition");
        limitNumber = serializedObject.FindProperty("limitNumber");
        enemyLimit = serializedObject.FindProperty("enemyLimit");
        allEnemiesDestroyed = serializedObject.FindProperty("allEnemiesDestroyed");
    }

    /// <inheritdoc />
    public override void OnInspectorGUI() {
        EditorGUILayout.PropertyField(enemyFactory);
        EditorGUILayout.PropertyField(spawnDelaySeconds);
        EditorGUILayout.PropertyField(enemiesPerSecond);
        EditorGUILayout.PropertyField(ySpawnPosition);

        float minx = minXSpawnPosition.floatValue;
        float maxx = maxXSpawnPosition.floatValue;
        GUIContent label = new GUIContent($"X Spawn Range ({minx:0.0} | {maxx:0.0})");
        EditorGUILayout.MinMaxSlider(label, ref minx, ref maxx, -10, 10);
        minXSpawnPosition.floatValue = minx;
        maxXSpawnPosition.floatValue = maxx;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(limitNumber);
        if (limitNumber.boolValue) {
            enemyLimit.intValue = EditorGUILayout.IntField("Max Enemies", enemyLimit.intValue);
            if (enemyLimit.intValue < 0) enemyLimit.intValue = 0;
        }
        EditorGUILayout.EndHorizontal();

        if (limitNumber.boolValue) {
            EditorGUILayout.PropertyField(allEnemiesDestroyed);
        }

        serializedObject.ApplyModifiedProperties();
    }
}