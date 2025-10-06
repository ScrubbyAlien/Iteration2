using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WinLosePort", menuName = "Win Lose Port")]
public class WinLosePort : ScriptableObject
{
    public event Action OnPlayerDeath;
    public event Action OnWin;

    private int numberOfEnemiesAlive;
    private bool finalWaveFinished;

    private void OnEnable() {
        numberOfEnemiesAlive = 0;
        finalWaveFinished = false;
    }

    public void PlayerDied() {
        OnPlayerDeath?.Invoke();
    }

    public void EnemySpawned(Enemy enemy) {
        numberOfEnemiesAlive++;
        enemy.OnDeactivate += () => {
            numberOfEnemiesAlive--;
            CheckIfWin();
        };
    }

    private void CheckIfWin() {
        if (numberOfEnemiesAlive == 0 && finalWaveFinished) OnWin?.Invoke();
    }

    public void FinalWaveFinished() {
        finalWaveFinished = true;
        CheckIfWin();
    }
}