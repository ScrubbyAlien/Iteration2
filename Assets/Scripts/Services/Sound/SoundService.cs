using System;
using System.Linq;
using UnityEngine;

public class SoundService : Service<SoundService>
{
    [SerializeField]
    private SoundFactory factory;
    [SerializeField, Tooltip("Path from any Resources folder where the sound assets are located")]
    private string soundsDirectory;

    [SerializeField]
    private bool mute;

    private Sound[] sounds;

    protected override void Register() {
        locator.Register(this);
    }

    protected void Start() {
        sounds = Resources.LoadAll<Sound>(soundsDirectory);
    }

    public void PlaySound(string name) {
        if (mute) return;
        Sound sound = sounds.First(s => s.name == name);
        if (sound) {
            SoundPlayer player = factory.GetProduct();
            player.Play(sound);
        }
    }
}