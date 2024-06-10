using GameState;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _goToMenuButton;
    [SerializeField] private Button _closeButton;
    
    private GameStateMachine _machine;

    [Inject]
    private void Construct(GameStateMachine machine) 
    {
        _machine = machine;
    }

    private void Awake()
    {
        _goToMenuButton.onClick.AddListener(LoadMenuScene);
        _closeButton .onClick.AddListener(Hide);
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(Hide);
        _goToMenuButton.onClick.RemoveListener(LoadMenuScene);
    }

    private void LoadMenuScene() 
    {
        _machine.Enter<LoadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("MainScene", null));
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide() 
    {
        gameObject.SetActive(false);
    }

    public bool IsShowing()
    {
        return gameObject.activeSelf;
    }
}
