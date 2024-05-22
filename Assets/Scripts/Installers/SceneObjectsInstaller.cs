using UnityEngine;
using Zenject;

public class SceneObjectsInstaller : MonoInstaller
{
    [SerializeField] private Portal _portal;
    //[SerializeField] private Field _field;
    [SerializeField] private GameLose _lose;

    public override void InstallBindings()
    {
        Container.Bind<Field>().FromNew()/*FromInstance(_field)*/.AsSingle();//.NonLazy();
        Container.Bind<Portal>().FromInstance(_portal).AsSingle().NonLazy();
        Container.Bind<GameLose>().FromInstance(_lose).AsSingle().NonLazy();
    }
}
