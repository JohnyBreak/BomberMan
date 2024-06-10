using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Restart : MonoBehaviour
{
    private Transition _screen;

    [Inject]
    private void Construct(Transition screen)
    {
        _screen = screen;
    }

    void Update()
    {
        if (Input.GetButtonDown("Restart")) 
        {
            _screen.FadeIn(ReLoadScene);
        }
    }

    private void ReLoadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
