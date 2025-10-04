using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private ScoreLocator scoreLocator;
    private ScoreService scoreService => scoreLocator.GetService();

    [SerializeField]
    private TMP_Text scoreText, multiplierText;

    void Start() {
        scoreService.OnIntStatChange += SetScoreText;
        SetScoreText(scoreService.initialIntValue);

        scoreService.OnFloatStatChange += SetMultiplierText;
        SetMultiplierText(scoreService.initialFloatValue);
    }

    private void SetScoreText(int newScore) {
        scoreText.text = newScore.ToString();
    }

    private void SetMultiplierText(float multiplier) {
        multiplierText.text = $"x{multiplier:0.0}";
    }
}