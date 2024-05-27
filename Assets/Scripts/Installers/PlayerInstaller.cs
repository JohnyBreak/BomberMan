using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    //[SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Container.Bind <PlayerStats>().FromMethod(GetPlayerStats).AsSingle();
        //Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<PlayerScore>().FromNew().AsSingle();
        Container.Bind<PlayerProvider>().FromNew().AsSingle();
    }

    private PlayerStats GetPlayerStats()
    {
        var stats = new PlayerStats(
            bombRadius: 1,
            maxBombRadius: 3,
            playerMoveSpeed: 2f,
            maxPlayerMoveSpeed: 3.3f,
            bombAmount: 1);

        return stats;
    }
}
