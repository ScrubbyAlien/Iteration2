using UnityEngine;

[CreateAssetMenu(fileName = "FollowPath", menuName = "Patterns/Movement/Follow Path")]
public class FollowPath : MovementPattern
{
    [SerializeField]
    private float margin;
    [SerializeField]
    private Vector2[] vertices;

    private int currentVertexIndex = 0;

    public override bool GetNextDirection(Enemy caller, out Vector2 direction) {
        Vector2 currentVertex = vertices[currentVertexIndex];
        Vector2 toVertex = currentVertex - (Vector2)caller.transform.position;
        direction = toVertex.normalized;
        if (toVertex.sqrMagnitude < margin * margin) {
            currentVertexIndex++;
            currentVertexIndex %= vertices.Length;
        }
        return true;
    }

    public override MovementPattern Copy(Vector2 position) {
        FollowPath copy = ScriptableObject.CreateInstance<FollowPath>();
        copy.vertices = vertices;
        copy.margin = margin;
        return copy;
    }

    public override void DrawGizmos(Transform transform) {
        if (vertices == null) return;
        if (vertices.Length < 2) return;
        for (int i = 0; i < vertices.Length; i++) {
            if (i == vertices.Length - 1) Gizmos.DrawLine(vertices[i], vertices[0]);
            else Gizmos.DrawLine(vertices[i], vertices[i + 1]);
        }
    }
}