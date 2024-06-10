using Zenject;
using UnityEngine;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioManager _audioManager;

    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle().NonLazy();
    }
}