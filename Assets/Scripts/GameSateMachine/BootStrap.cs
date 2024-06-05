using GameState;
using UnityEngine;
using Utils;

public class BootStrap : MonoBehaviour, ICoroutineRunner
{
    public GameStateMachine StateMachine;
    
    void Start()
    {
        StateMachine = new GameStateMachine(new SceneLoader(this));
        StateMachine.Enter<BootstrapState>();
        DontDestroyOnLoad(this.gameObject);
    }
}