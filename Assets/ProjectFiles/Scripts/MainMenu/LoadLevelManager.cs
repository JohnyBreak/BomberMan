using UnityEngine;
using Zenject;
using GameState;

public class LoadLevelManager : MonoBehaviour
{
    [SerializeField] private ChosenLevel _chosenLevel;

    private IStorageService _storageService;
    private GameStateMachine _machine;
    private Transition _transition;

    [Inject]
    private void Construct(IStorageService storageService, GameStateMachine machine, Transition transition)
    {
        _storageService = storageService;
        _machine = machine;
        _transition = transition;
    }

    public void LoadLevel()
    {
        _storageService.Save(
            "LevelNumber",
            _chosenLevel.Level, 
            FadeIn);
    }

    private void FadeIn(bool param) 
    {
        _transition.FadeIn(EnterLoadState);
    }

    private void EnterLoadState() 
    {
        _machine.Enter<LoadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("CoreScene", () =>
        {
            _machine.Enter<GamePrepareState>();
        }));
    }

}
