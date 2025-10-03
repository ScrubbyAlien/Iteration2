using UnityEngine;

public class CorridorColliders : MonoBehaviour
{
    [SerializeField]
    private Locator<Blackbars> blackbarsLocator;
    private Blackbars blackbars => blackbarsLocator.GetService();

    [SerializeField]
    private EdgeCollider2D top, bottom, right, left;

    [SerializeField]
    private float verticalOffset;

    private void Start() {
        Rect corridorRect = blackbars.CorridorRect();

        top.offset = new Vector2(0, corridorRect.y + corridorRect.height - verticalOffset);
        bottom.offset = new Vector2(0, corridorRect.y + verticalOffset);
        right.offset = new Vector2(corridorRect.x + corridorRect.width, 0);
        left.offset = new Vector2(corridorRect.x, 0);
    }
}