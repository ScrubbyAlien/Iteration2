using UnityEngine;

public class Blackbars : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer blackbarLeft, blackbarRight;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField, Min(0)]
    private float corridorWidth;

    public void LerpCorridorWidth(float newWidth, float time) {
        // slide the black bars dramatically
    }

    public void SetCorridorWidth(float width) {
        // calculate blackbars new size
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect * 2;
        float barWidth = (cameraWidth - width) / 2f;
        float offset = (width + barWidth) / 2f;
        Vector3 camPos = mainCamera.transform.position;
        blackbarLeft.transform.position = new Vector3(camPos.x - offset, camPos.y, camPos.z + 1f);
        blackbarRight.transform.position = new Vector3(camPos.x + offset, camPos.y, camPos.z + 1f);
        blackbarLeft.size = new Vector3(barWidth, mainCamera.orthographicSize * 2, 1);
        blackbarRight.size = new Vector3(barWidth, mainCamera.orthographicSize * 2, 1);
    }
}