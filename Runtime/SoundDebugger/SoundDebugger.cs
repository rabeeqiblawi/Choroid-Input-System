using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebugSound
{
    normal,
    good,
    error
}

[RequireComponent(typeof(AudioSource))]
public class SoundDebugger

    : MonoBehaviour
{
    [SerializeField] private AudioClip normal, error, positive;
    private AudioSource _audioSource;
    public AudioSource AudioSource
    {
        get
        {
            if (_audioSource == null)
                _audioSource = GetComponent<AudioSource>();
            return _audioSource;
        }
    }
    public static SoundDebugger Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void PLayDebugSound(DebugSound debugSound)
    {
        switch (debugSound)
        {
            case DebugSound.normal:
                AudioSource.clip = normal;
                break;
            case DebugSound.good:
                AudioSource.clip = positive;
                break;
            case DebugSound.error:
                AudioSource.clip = error;
                break;
            default:
                break;
        }
        AudioSource.Play();
    }
    public void PlayNormal()
    {
        PLayDebugSound(DebugSound.normal);
    }
    public void PlayError()
    {
        PLayDebugSound(DebugSound.error);
    }
    public void PlayGood()
    {
        PLayDebugSound(DebugSound.good);
    }
}

public static partial class Extentions
{
    public static void DebugSound(this MonoBehaviour mono, DebugSound debugSound)
    {
        SoundDebugger.Instance.PLayDebugSound(debugSound);
    }
}
