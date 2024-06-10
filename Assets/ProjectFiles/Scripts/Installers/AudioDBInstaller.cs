using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AudioDBInstaller", menuName = "Installers/AudioDBInstaller")]
public class AudioDBInstaller : ScriptableObjectInstaller<AudioDBInstaller>
{
    [SerializeField] private AudioDB _soundDB;

    public override void InstallBindings()
    {
        Container.Bind<AudioDB>().FromInstance(_soundDB);
    }
}