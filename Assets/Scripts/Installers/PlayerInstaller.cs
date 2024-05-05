using Zenject;

public class PlayerInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerScore>().FromNew().AsSingle();
    }
}
