

using UnityEngine;

public class PlayerStats
{
    private int _bombRadius;
    private float _playerMoveSpeed;

    private int _maxBombRadius;
    private float _maxPlayerMoveSpeed;

    public float PlayerMoveSpeed => _playerMoveSpeed;
    public int BombRadius => _bombRadius;

    public PlayerStats(
        int bombRadius,
        int maxBombRadius, 
        float playerMoveSpeed,
        float maxPlayerMoveSpeed) 
    {
        _bombRadius = bombRadius;
        _playerMoveSpeed = playerMoveSpeed;
        _maxBombRadius = maxBombRadius;
        _maxPlayerMoveSpeed = maxPlayerMoveSpeed;
    }

    public void IncreasePlayerSpeed(float speedAmount) 
    {
        if (_playerMoveSpeed + speedAmount > _maxPlayerMoveSpeed) 
        {
            _playerMoveSpeed = _maxPlayerMoveSpeed;
            return;
        }

        _playerMoveSpeed += speedAmount;
    }

    public void IncreaseBombRadius(int amount)
    {
        if (_bombRadius + amount > _maxBombRadius)
        {
            _bombRadius = _maxBombRadius;
            return;
        }

        _bombRadius += amount;
        Debug.LogError(_bombRadius);
    }
}
