using System;
using UnityEngine;

public class PlayerProvider
{
    public event Action <Player> OnPlayerSetted;

    private Player _player;

    public Player GetPlayer() 
    {
        return _player;
    }

    public void SetPlayer(Player player) 
    {
        _player = player;
        OnPlayerSetted?.Invoke(_player);
    }
}
