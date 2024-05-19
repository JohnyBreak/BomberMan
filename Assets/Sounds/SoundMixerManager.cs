using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    public void SetMasterVolume(float level) 
    {
        _mixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        _mixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundVolume(float level)
    {
        _mixer.SetFloat("SoundVolume", Mathf.Log10(level) * 20f);
    }
}
