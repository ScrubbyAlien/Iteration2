using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicService : Service<MusicService>
{
    [SerializeField]
    private string musicDirectory, startMusic;
    [SerializeField]
    private bool mute;

    private AudioSource source;
    private Sound[] musics;

    protected override void Register() {
        locator.Register(this);
    }

    protected void Start() {
        source = GetComponent<AudioSource>();
        musics = Resources.LoadAll<Sound>(musicDirectory);
        if (startMusic != "") PlayMusic(startMusic);
    }

    public void PlayMusic(string name) {
        if (mute) return;
        Sound music = musics.First(m => m.name == name);
        source.clip = music.clip;
        source.volume = music.volume;
        source.pitch = music.pitch;
        source.loop = music.looping;
        source.Play();
    }
}