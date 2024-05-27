using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour, IExplodable
{
    private Player _player;
    private GameLose _lose;
    private PlayerDeadText _deadText;

    [Inject]
    private void Construct(
        PlayerProvider provider, 
        PlayerDeadText playerDeadText,
        GameLose lose) 
    {
        _deadText = playerDeadText;
        _lose = lose;

        Player player = provider.GetPlayer();

        if (player == null) 
        {
            provider.OnPlayerSetted += (newPlayer) =>
            {
                _player = newPlayer;
            };
            return;
        }

        _player = player;
    }

    public void Explode()
    {
        TakeDamage();
    }

    private void TakeDamage() 
    {
        _player.Kill();
        _deadText.Activate();
        _lose.Activate();
    }
}
