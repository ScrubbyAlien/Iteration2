using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image pips;
    [SerializeField, Tooltip("The width of the pips image / # of pips")]
    private float pipWidth;
    [SerializeField]
    private int pipsPerHealth;

    private float pipsBaseHeight;
    private float currentPips;
    private float currentWidth => currentPips * pipWidth;

    private void Start() {
        pipsBaseHeight = pips.rectTransform.rect.height;
    }

    private void AdjustHealthBar(int deltaHealth) {
        currentPips += deltaHealth * pipsPerHealth;
        currentPips = Mathf.Max(currentPips, 0);
        pips.rectTransform.sizeDelta = new Vector2(currentWidth, pipsBaseHeight);
    }
}