using UnityEngine;
using Zenject;

public class SceneObjectsInstaller : MonoInstaller
{
    [SerializeField] private Portal _portal;
    [SerializeField] private Field _field;

    public override void InstallBindings()
    {
        Container.Bind<Field>().FromInstance(_field).AsSingle().NonLazy();
        Container.Bind<Portal>().FromInstance(_portal).AsSingle().NonLazy();
    }
}
