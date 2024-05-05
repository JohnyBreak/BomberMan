using UnityEngine;
using Zenject;

public class PortalInstaller : MonoInstaller
{
    [SerializeField] private Portal _portal;

    public override void InstallBindings()
    {
        Container.Bind<Portal>().FromInstance(_portal).AsSingle().NonLazy();
    }
}
