using System;
using System.Collections;
using UnityEngine;

public class ScoreService : Service<ScoreService>, IIntegerStat, IFloatStat
{
    public string statId => "scoremanager";
    public event Action<int> OnIntStatChange;
    public event Action<float> OnFloatStatChange;
    public int readInt => currentScore;
    public float readFloat => currentMultiplier;
    public int initialIntValue => 0;
    public float initialFloatValue => 1;

    [SerializeField, Min(0)]
    private int maxScore;
    [SerializeField, Min(0)]
    private float maxMultiplier, multiplierIncramentSize, multiplierLifetime;
    private float multiplierDieTime;

    private float _cm;
    private float currentMultiplier {
        get => _cm;
        set {
            float newMultiplier = Mathf.Min(value, maxMultiplier);
            _cm = newMultiplier;
            OnFloatStatChange?.Invoke(newMultiplier);
        }
    }
    private int _cs;
    private int currentScore {
        get => _cs;
        set {
            int newScore = Math.Min(value, maxScore);
            _cs = newScore;
            OnIntStatChange?.Invoke(newScore);
        }
    }

    /// <inheritdoc />
    protected override void Register() {
        locator.Register(this);
    }
    private void Start() {
        currentScore = initialIntValue;
        currentMultiplier = initialFloatValue;
    }

    private void Update() {
        if (Time.time > multiplierDieTime) {
            currentMultiplier = initialFloatValue;
        }
    }

    public void GainScore(int score) {
        currentScore += Mathf.RoundToInt(score * currentMultiplier);
        currentMultiplier += multiplierIncramentSize;
        multiplierDieTime = Time.time + multiplierLifetime;
    }
}