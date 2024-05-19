using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour, IExplodable
{
    private Player _player;
    private GameLose _lose;
    private PlayerDeadText _deadText;

    [Inject]
    private void Construct(
        Player player, 
        PlayerDeadText playerDeadText,
        GameLose lose) 
    {
        _player = player;
        _deadText = playerDeadText;
        _lose = lose;
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
