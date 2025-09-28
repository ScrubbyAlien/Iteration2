using System.Collections;
using UnityEngine;

public class Cooldown
{
    private float cooldownLength;
    private float finishTime;
    private bool started;

    public Cooldown(float length) {
        cooldownLength = length;
    }

    public void Start() {
        if (started) return;
        started = true;
        finishTime = Time.time + cooldownLength;
    }

    public void Stop() {
        started = false;
        finishTime = 0;
    }

    public void Restart() {
        Stop();
        Start();
    }

    public bool on {
        get {
            started = Time.time < finishTime;
            return started;
        }
    }
}