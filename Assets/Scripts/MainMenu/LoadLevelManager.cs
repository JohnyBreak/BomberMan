using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LoadLevelManager : MonoBehaviour
{

    [SerializeField] private ChosenLevel _chosenLevel;
    private IStorageService _storageService;

    [Inject]
    private void Construct(IStorageService storageService) 
    {
        _storageService = storageService;
    }

    public void LoadLevel() 
    {
        _storageService.Save(
            "LevelNumber", 
            _chosenLevel.Level, 
            (param) => 
                { 
                    SceneManager.LoadScene("SampleScene"); 
                }
            );

    }
}
