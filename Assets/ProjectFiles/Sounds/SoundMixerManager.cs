using DG.Tweening;
using GameState;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private float _startValue;
    [SerializeField] private Slider _slider;

    private GameStateMachine _machine;

    [Inject]
    private void Construct(GameStateMachine machine)
    {
        _machine = machine;


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

    private void Awake()
    {
        _slider.value = _startValue;

        SetMasterVolume(_slider.value);
        SetMusicVolume(_slider.value);

        _machine.StateChangedEvent += OnStateChanged;
    }

    private void OnDestroy()
    {
        _machine.StateChangedEvent -= OnStateChanged;
    }

    private void OnStateChanged(IExitableState state)
    {
        if (state is GamePauseState)
        {
            _mixer.DOPause();
            return;
        }

        if (state is GamePlayState)
        {
            _mixer.DOPlay();
            return;
        }
    }
}
