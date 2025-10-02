using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "SoundAsset")]
public class Sound : ScriptableObject
{
    [SerializeField]
    private AudioClip audioClip;
    public AudioClip clip => audioClip;

    [SerializeField, Range(0f, 1f)]
    private float volumeScale = 1;
    public float volume => volumeScale;

    [SerializeField, Range(-3, 3)]
    private float pitchModifier = 1;
    public float pitch => pitchModifier;

    [SerializeField]
    private bool loop;
    public bool looping => loop;
}