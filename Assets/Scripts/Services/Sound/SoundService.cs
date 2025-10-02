using System;
using System.Linq;
using UnityEngine;

public class SoundService : Service<SoundService>
{
    [SerializeField]
    private SoundFactory factory;
    [SerializeField]
    private Sound[] sounds;

    protected override void Register() {
        locator.Register(this);
    }

    public void PlaySound(string name) {
        Sound sound = sounds.First(s => s.name == name);
        if (sound) {
            SoundPlayer player = factory.GetProduct();
            player.Play(sound);
        }
    }
}