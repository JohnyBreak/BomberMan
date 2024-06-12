using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _ambienceource;
    [SerializeField] private AudioSource _soundSource;
    
    public void PlayOneShot(AudioClip clip, float volume = -1) 
    {
        if (volume >= 0)
        {
            _musicSource.volume = volume;
        }

        _soundSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip, bool loop = true, float volume = -1)
    {
        _musicSource.clip = clip;

        _musicSource.loop = loop;
        
        if (volume >= 0)
        {
            _musicSource.volume = volume;
        }

        _musicSource.Play();
    }

    public void StopAllSounds() 
    {
        _musicSource.Stop();
        _ambienceource.Stop();
        _soundSource.Stop();
    }
}
