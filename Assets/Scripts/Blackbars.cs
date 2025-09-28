using UnityEngine;

public class Blackbars : MonoBehaviour
{
    [SerializeField]
    private Transform blackbarLeft, blackbarRight;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField, Min(0)]
    private float corridorWidth;

    private void OnValidate() {
        if (mainCamera) SetCorridorWidth(corridorWidth);
    }

    public void SetNewCorridorWidth(float newWidth, float time) {
        // slide the black bars dramatically
    }

    private void SetCorridorWidth(float width) {
        // calculate blackbars new size
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect * 2;
        float barWidth = (cameraWidth - width) / 2f;
        float offset = (width + barWidth) / 2f;
        Vector3 camPos = mainCamera.transform.position;
        blackbarLeft.position = new Vector3(camPos.x - offset, camPos.y, camPos.z + 1f);
        blackbarRight.position = new Vector3(camPos.x + offset, camPos.y, camPos.z + 1f);
        blackbarLeft.localScale = new Vector3(barWidth, mainCamera.orthographicSize * 2, 1);
        blackbarRight.localScale = new Vector3(barWidth, mainCamera.orthographicSize * 2, 1);
    }
}