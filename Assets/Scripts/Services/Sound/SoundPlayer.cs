using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour, IPoolObject
{
    private AudioSource source;

    private void OnEnable() {
        source = GetComponent<AudioSource>();
    }

    public void Play(Sound sound) {
        source.volume = sound.volume;
        source.clip = sound.clip;
        source.Play();
        StartCoroutine(ReleaseTimer(sound.clip.length));
    }

    private IEnumerator ReleaseTimer(float duration) {
        yield return new WaitForSeconds(duration);
        pool.Release(this);
    }

    public ObjectPool<IPoolObject> pool { get; set; }
    public GameObject gameObjectRef => gameObject;
    public void Activate() {
        gameObject.SetActive(true);
    }
    public void Deactivate() {
        gameObject.SetActive(false);
    }
}