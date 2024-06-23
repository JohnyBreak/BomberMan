using System;

public class PlayerScore
{
    public Action<uint> ScoreUpdated;

    private uint _score;

    public uint CurrentScore => _score;

    public void Increase(uint addScore) 
    {
        _score += addScore;

        ScoreUpdated?.Invoke(_score);
    }
}
