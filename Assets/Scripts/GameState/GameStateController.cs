using System.Collections.Generic;

public class GameStateController
{
    private IGameState _currentState;
    private GameStates _gameStates;

    public GameStateController(GameStates gameStates) 
    {
        _gameStates = gameStates;
        _currentState = _gameStates.GetState(GamePlayState.Name);
    }

    public bool CanSetState(string stateName) 
    {
        var state = _gameStates.GetState(stateName);

        return _currentState.CanChangeToState(state);
    }

    public bool SetState(string stateName) 
    {
        if (CanSetState(stateName) == false) 
        {
            return false;
        }

        _currentState = _gameStates.GetState(stateName);
        return true;
    }

    //public IGameState GetState()
    //{
    //    return _currentState;
    //}

    public bool IsCurrentState(string stateName)
    {
        var state = _gameStates.GetState(stateName);

        if (_currentState == state) 
        {
            return true;
        }

        return false;
    }
}

public interface IGameState 
{
    public bool CanChangeToState(IGameState state);
}

public class GamePlayState : IGameState
{
    public const string Name = "GamePlay";

    public bool CanChangeToState(IGameState state)
    {
        return true;
    }
}

public class WinState : IGameState
{
    public const string Name = "Win";

    public bool CanChangeToState(IGameState state)
    {
        return true;
    }
}

public class LoseState : IGameState
{
    public const string Name = "Lose";

    public bool CanChangeToState(IGameState state)
    {
        return true;
    }
}

public class GameStates 
{
    public readonly Dictionary<string, IGameState> _states 
        = new Dictionary<string, IGameState>() 
    {
            { GamePlayState.Name, new GamePlayState() },
            { WinState.Name, new WinState() },
            { LoseState.Name, new LoseState() },
    };

    public IGameState GetState(string stateName) 
    {
        return _states[stateName];
    }
}
