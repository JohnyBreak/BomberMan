using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LoadLevelManager : MonoBehaviour
{

    [SerializeField] private ChosenLevel _chosenLevel;
    private IStorageService _storageService;
    private TransitionScreen _screen;

    [Inject]
    private void Construct(IStorageService storageService, TransitionScreen screen) 
    {
        _storageService = storageService;
        _screen = screen;
    }

    public void LoadLevel() 
    {
        _storageService.Save(
            "LevelNumber", 
            _chosenLevel.Level, 
            (param) => 
                {
                    _screen.FadeIn(callBack: LoadScene);
                }
            );
    }

    private void LoadScene() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
