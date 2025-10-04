using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField, EnforceInterface(typeof(IIntegerStat))]
    private GameObject healthHaver;
    private IIntegerStat health;
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
        health = healthHaver.GetComponent<IIntegerStat>();
        health.OnStatChange += AdjustHealthBar;
        currentPips = health.initialValue * pipsPerHealth;
        pipsBaseHeight = pips.rectTransform.rect.height;
    }

    private void AdjustHealthBar(int newHealth) {
        currentPips = newHealth * pipsPerHealth;
        currentPips = Mathf.Max(currentPips, 0);
        pips.rectTransform.sizeDelta = new Vector2(currentWidth, pipsBaseHeight);
    }
}