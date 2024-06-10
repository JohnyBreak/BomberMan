using GameState;
using UnityEngine;
using Utils;
using Zenject;

public class BootStrap : MonoBehaviour, ICoroutineRunner
{
    private GameStateMachine _stateMachine;

    [Inject]
    private void Construct(GameStateMachine gameStateMachine) 
    {
        _stateMachine = gameStateMachine;
    }

    void Start()
    {
        _stateMachine.Enter<BootstrapState>();
        DontDestroyOnLoad(this.gameObject);
    }
}