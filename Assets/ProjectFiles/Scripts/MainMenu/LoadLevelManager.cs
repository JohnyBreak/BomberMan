using UnityEngine;
using Zenject;
using GameState;

public class LoadLevelManager : MonoBehaviour
{
    [SerializeField] private ChosenLevel _chosenLevel;
 
    private IStorageService _storageService;
    private GameStateMachine _machine;

    [Inject]
    private void Construct(IStorageService storageService, GameStateMachine machine) 
    {
        _storageService = storageService;
        _machine = machine;
    }

    public void LoadLevel() 
    {
        _storageService.Save(
            "LevelNumber", 
            _chosenLevel.Level, 
            (param) => 
                {
                    _machine.Enter<LoadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("CoreScene", () => 
                    {
                        _machine.Enter<GamePlayState>();
                    }
                ));
                }
            );
    }
}
