using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private float _startValue;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.value = _startValue;

        SetMasterVolume(_slider.value);
        SetMusicVolume(_slider.value);
    }

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
