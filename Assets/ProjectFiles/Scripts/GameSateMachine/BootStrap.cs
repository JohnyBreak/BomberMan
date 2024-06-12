using GameState;
using UnityEngine;
using Zenject;

public class BootStrap : MonoBehaviour
{
    private GameStateMachine _stateMachine;

    [Inject]
    private void Construct(GameStateMachine gameStateMachine) 
    {
        _stateMachine = gameStateMachine;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        _stateMachine.Initialize();

        _stateMachine.Enter<BootstrapState>();
    }
}