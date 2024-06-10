using Zenject;

public class SaveInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IStorageService>().To<JsonFileStorageService>().FromNew().AsSingle();
    }
}
