using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _goToMenuButton;
    [SerializeField] private Button _closeButton;

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
        SceneManager.LoadScene(0);
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
