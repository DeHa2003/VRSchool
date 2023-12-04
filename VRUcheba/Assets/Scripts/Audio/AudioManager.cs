using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0, 1f)] public float volume;
    [Range(0, 1f)] public float pitch;
    public bool isPlayOnAwake;
    public bool isLoop;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;

        foreach (var s in sounds)
        {
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.isLoop;
            s.audioSource.playOnAwake = s.isPlayOnAwake;
            if (s.isPlayOnAwake)
                s.audioSource.Play();
        }
    }

    public void PlaySound(string name)
    {
        Debug.Log(name);
        Sound s = Array.Find(sounds.ToArray(), sound => sound.name == name);
        if(s == null)
        {
            throw new Exception($"Not found sound - {name}");
        }
        s.audioSource.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds.ToArray(), sound => sound.name == name);
        if (s == null)
        {
            throw new Exception($"Not found sound - {name}");
        }
        s.audioSource.Stop();
    }
}
