using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _ambienceource;
    [SerializeField] private AudioSource _soundSource;
    //private GameObject _parent;

    //public AudioManager()
    //{
    //    _parent = new GameObject("AudioManager");
        
    //    _musicSource = new GameObject("MusicSource").AddComponent<AudioSource>();
    //    _musicSource.transform.parent = _parent.transform;

    //    _ambienceource = new GameObject("Ambienceource").AddComponent<AudioSource>();
    //    _ambienceource.transform.parent = _parent.transform;

    //    _soundSource = new GameObject("SoundSource").AddComponent<AudioSource>();
    //    _soundSource.transform.parent = _parent.transform;

    //    _musicSource.playOnAwake = false;
    //    _ambienceource.playOnAwake = false;
    //    _soundSource.playOnAwake = false;
    //    //GameObject.DontDestroyOnLoad(_parent);
    //}
    
    public void PlayOneShot(AudioClip clip) 
    {
        _soundSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        _musicSource.clip = clip;

        _musicSource.loop = loop;

        _musicSource.Play();
    }

    public void StopAllSounds() 
    {
        _musicSource.Stop();
        _ambienceource.Stop();
        _soundSource.Stop();
    }
}
