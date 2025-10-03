using UnityEngine;
using UnityEngine.UI;

public class Blackbars : Service<Blackbars>
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Image blackbarLeft, blackbarRight;

    [SerializeField, Range(0, 1), Tooltip("The width of the corridor as a percentage of the width of the screen")]
    private float corridorWidth;

    public void LerpCorridorWidth(float newWidth, float time) {
        // slide the black bars dramatically
    }

    public void SetCorridorWidth(float percentageWidth) {
        // calculate blackbars new size
        float realWidth = canvas.pixelRect.width * percentageWidth;
        float canvasWidth = canvas.pixelRect.width;
        float barWidth = (canvasWidth - realWidth) / 2f;
        blackbarLeft.rectTransform.sizeDelta = new Vector2(barWidth, 0);
        blackbarRight.rectTransform.sizeDelta = new Vector2(barWidth, 0);
    }
    /// <inheritdoc />
    protected override void Register() {
        locator.Register(this);
    }

    public Rect CorridorRect() {
        // should probably reference actual corrider width so it works with the lerp
        // this will only return the rect for the corridor width that is serilialized
        // referencePixelsPerUnit is not correct unless resolution of screen is 1080p
        float realWidth = canvas.pixelRect.width * corridorWidth;
        float width = realWidth / canvas.referencePixelsPerUnit;
        float height = canvas.pixelRect.height / canvas.referencePixelsPerUnit;
        float barWidth = (canvas.pixelRect.width - realWidth) / 2f;
        float x = (barWidth - canvas.pixelRect.width / 2) / canvas.referencePixelsPerUnit;
        float y = -(canvas.pixelRect.height / 2) / canvas.referencePixelsPerUnit;
        return new Rect(x, y, width, height);
    }
}