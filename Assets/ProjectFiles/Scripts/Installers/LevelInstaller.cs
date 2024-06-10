using Zenject;

public class LevelInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<LevelSystem>().FromNew().AsSingle();
    }
}
