using UnityEngine;

public class PlayerStats
{
    private int _bombRadius;
    private float _playerMoveSpeed;

    private int _maxBombRadius;
    private float _maxPlayerMoveSpeed;

    private int _bombAmount;

    public float PlayerMoveSpeed => _playerMoveSpeed;
    public int BombRadius => _bombRadius;

    public PlayerStats(
        int bombRadius,
        int maxBombRadius, 
        float playerMoveSpeed,
        float maxPlayerMoveSpeed,
        int bombAmount) 
    {
        _bombRadius = bombRadius;
        _playerMoveSpeed = playerMoveSpeed;
        _maxBombRadius = maxBombRadius;
        _maxPlayerMoveSpeed = maxPlayerMoveSpeed;
        _bombAmount = bombAmount;
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
    }

    public bool EnoughBomb() 
    {
        if (_bombAmount < 1) 
        {
            return false;
        }

        _bombAmount--;
        return true;
    }

    public void ReturnBomb() 
    {
        _bombAmount++;
    }
}
