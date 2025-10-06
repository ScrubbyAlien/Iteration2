using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private WinLosePort winLosePort;
    [SerializeField]
    private TMP_Text text;
    [SerializeField, TextArea(1, 3)]
    private string openingMessage;
    [SerializeField]
    private float openingDisplayTime;
    [SerializeField, TextArea(1, 3)]
    private string winMessage;
    [SerializeField, TextArea(1, 3)]
    private string loseMessage;
    [SerializeField]
    private float restartTime;
    [SerializeField]
    private string menuSceneName;

    private void Start() {
        DisplayMessage(openingMessage, openingDisplayTime);
        winLosePort.OnPlayerDeath += OnPlayerDeath;
        winLosePort.OnWin += OnWin;
    }

    private void OnPlayerDeath() {
        DisplayMessage(loseMessage, restartTime);
        StartCoroutine(DelayedAction(restartTime, () => LoadScene(menuSceneName)));
    }

    private void OnWin() {
        DisplayMessage(winMessage, restartTime);
        StartCoroutine(DelayedAction(restartTime, () => LoadScene(menuSceneName)));
    }

    private void DisplayMessage(string message, float duration) {
        text.gameObject.SetActive(true);
        text.text = message;
        StartCoroutine(DelayedAction(duration, () => text.gameObject.SetActive(false)));
    }

    private IEnumerator DelayedAction(float time, Action action) {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }

    private void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}